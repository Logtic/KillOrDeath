using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MonsterType {Small, Abokado, Jamong, Kiwi }
public enum MonsterState {Idle, Chase, Attack, Dead }
public abstract class Enemy : MonoBehaviour {

    public EnemyBattleTrigger enemyTrigger;
    public string enemyName;
    public int enemyAtk;
    public int enemyMaxHp;
    public int enemyCurrentHp;
    public float enemySpeed;

    public bool direction; // false -> left, true -> right
    public bool limitMove;

    public virtual void SetInitState() {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player.GetComponent<PlayerController>().player.playerType == PlayerType.Tomato)
            Physics2D.IgnoreCollision(player.GetComponent<PlayerController>().player.gameObject.GetComponent<CircleCollider2D>(), GetComponent<Collider2D>());
        else
            Physics2D.IgnoreCollision(player.GetComponent<PlayerController>().player.gameObject.GetComponent<BoxCollider2D>(), GetComponent<Collider2D>());
    }
    
    public virtual void MoveRight() { this.transform.position = new Vector2(this.transform.position.x + enemySpeed * Time.deltaTime, this.transform.position.y);
        enemyTrigger.gameObject.GetComponent<SpriteRenderer>().flipX = false;
    }
    public virtual void MoveLeft() { this.transform.position = new Vector2(this.transform.position.x - enemySpeed * Time.deltaTime, this.transform.position.y);
        enemyTrigger.gameObject.GetComponent<SpriteRenderer>().flipX = true;
    }
    
    public virtual void IdleState()
    {
        if (enemyCurrentHp < enemyMaxHp)
        {
            enemyTrigger.monsterState = MonsterState.Chase;
        }
        if (direction)
            MoveRight();
        else
            MoveLeft();
    }
    public virtual void ChaseState() {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (!limitMove)
        {
            if (player.transform.position.x > this.transform.position.x)
            {
                direction = true;
                MoveRight();
            }
            else
            {
                direction = false;
                MoveLeft();
            }
        }
        else
        {
            if (direction == true && player.transform.position.x > this.transform.position.x)
            {
                limitMove = false;
                MoveRight();
            }
            else if (direction == false && player.transform.position.x < this.transform.position.x)
            {
                limitMove = false;
                MoveLeft();
            }
        }
    }
    public virtual void AttackState() { }
    public virtual void DeadState() { }

    public virtual void DeadCheck() { }
    public virtual void EnemyMovement(MonsterState monsterState) {
        switch (monsterState) {
            case MonsterState.Idle:
                IdleState();
                break;
            case MonsterState.Chase:
                ChaseState();
                break;
            case MonsterState.Attack:
                AttackState();
                break;
            case MonsterState.Dead:
                DeadState();
                
                break;
        }
    }
}
