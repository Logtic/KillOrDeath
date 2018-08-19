using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBattleTrigger : MonoBehaviour { // 적의 전투관련 모두
    
    public MonsterType monsterType;
    public MonsterState monsterState;
    public GameObject enemyAttackEffect;
    private Animator animator;
    public bool encounterPlayer;
    public bool endAttack;
    public bool isDead = false;

    public int enemyHeight;

    private void EnemyAttack()
    {
        enemyAttackEffect.GetComponent<EnemyAttackEffect>().attack = false;
        enemyAttackEffect.SetActive(true);
        
    }

    private void EnemyAttackDone()
    {
        enemyAttackEffect.GetComponent<EnemyAttackEffect>().attack = false;
        enemyAttackEffect.SetActive(false);
        endAttack = true;
    }

    

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            encounterPlayer = true;
            switch (monsterState)
            {
                case MonsterState.Idle:
                    encounterPlayer = false;
                    monsterState = MonsterState.Chase;
                    break;
                case MonsterState.Chase:
                    monsterState = MonsterState.Attack;
                    endAttack = false;
                    break;
                default:
                    break;
            }
                
        }
    }

    private void Start()
    {
        animator = this.GetComponent<Animator>();
    }
    //몬스터가 플레이어를 어케 감지하는가
}
