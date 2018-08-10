using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEnemyBattleTrigger : MonoBehaviour { // 적의 전투관련 모두
    public MonsterType monsterType;
    public MonsterState monsterState;
    public bool encounterPlayer;
    public bool endAttack;
    public bool isDead;

    private void EnemyAttack(Player player)
    {
        endAttack = true;
        isDead = false;
        BattleController.AttackEnemyToPlayer(player, this.transform.parent.GetComponent<Enemy>());
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

    //몬스터가 플레이어를 어케 감지하는가
}
