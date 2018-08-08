using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEnemyBattleTrigger : MonoBehaviour {
    public MonsterType monsterType;
    public MonsterState monsterState;
    public bool encounterPlayer;


    private void OnTriggerEnter2D(Collider2D collision)
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
                    break;
                case MonsterState.Attack:
                    encounterPlayer = false;
                    monsterState = MonsterState.Chase;
                    break;
                case MonsterState.Dead:
                    break;
            }
                
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().nearEnemy = this.transform.parent.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().nearEnemy = null;
        }
    }
}
