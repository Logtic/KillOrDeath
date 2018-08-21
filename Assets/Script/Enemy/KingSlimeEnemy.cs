using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingSlimeEnemy : Enemy {
    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyFloorTrigger" && enemyTrigger.monsterState != MonsterState.Attack)
        {
            direction = !direction;
            limitMove = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyFloorTrigger" && enemyTrigger.monsterState != MonsterState.Attack)
        {
            limitMove = false;
        }
    }
    public override void SetInitState()
    {
        attacking = false;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Physics2D.IgnoreCollision(player.GetComponent<BoxCollider2D>(), GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(player.GetComponent<EdgeCollider2D>(), GetComponent<Collider2D>());
    }


    public override void MoveLeft()
    {
        this.transform.position = new Vector2(this.transform.position.x - enemySpeed * Time.deltaTime, this.transform.position.y);
    }
    public override void MoveRight()
    {
        this.transform.position = new Vector2(this.transform.position.x + enemySpeed * Time.deltaTime, this.transform.position.y);
    }

    

    public override void IdleState()
    {
        
        if (direction)
        {
            enemyTrigger.gameObject.GetComponent<Animator>().SetBool("Direction", true);
            enemyTrigger.gameObject.GetComponent<Animator>().SetInteger("State", 1);
            MoveRight();
        }
            
        else
        {
            enemyTrigger.gameObject.GetComponent<Animator>().SetBool("Direction", false);
            enemyTrigger.gameObject.GetComponent<Animator>().SetInteger("State", 1);
            MoveLeft();
        }
            
    }

    public override void ChaseState()
    {
        enemyTrigger.gameObject.GetComponent<Animator>().SetInteger("State", 2);
        if (!limitMove)
        {
            if (UIInGame.UIInstance.player.transform.position.x > this.transform.position.x)
            {
                enemyTrigger.gameObject.GetComponent<Animator>().SetBool("Direction", true);
                direction = true;
                MoveRight();
            }
            else
            {
                enemyTrigger.gameObject.GetComponent<Animator>().SetBool("Direction", false);
                direction = false;
                MoveLeft();
            }
        }
        else
        {
            if (direction == true && UIInGame.UIInstance.player.transform.position.x > this.transform.position.x)
            {
                enemyTrigger.gameObject.GetComponent<Animator>().SetBool("Direction", true);
                limitMove = false;
                MoveRight();
            }
            else if (direction == false && UIInGame.UIInstance.player.transform.position.x < this.transform.position.x)
            {
                enemyTrigger.gameObject.GetComponent<Animator>().SetBool("Direction", false);
                limitMove = false;
                MoveLeft();
            }
        }


    }

    private bool attacking;
    public override void AttackState()
    {
        // 애니메이션에 끝날 때 endAttack을 true로 놓을 것
        
        enemyTrigger.gameObject.GetComponent<Animator>().SetInteger("State", 3);
        if (enemyTrigger.endAttack) // 공격 후에는 다시 Chase모드로
        {
            enemyTrigger.monsterState = MonsterState.Chase;
            enemyTrigger.endAttack = false;
            attacking = false;

        }
        else
        {
            if (direction && attacking == false) // 오른쪽으로 공격
            {
                enemyTrigger.gameObject.GetComponent<Animator>().SetBool("Direction", true);
                attacking = true;
            }
            else if (!direction && attacking == false) // 왼쪽으로 공격
            {
                enemyTrigger.gameObject.GetComponent<Animator>().SetBool("Direction", false);
                attacking = true;
            }

        }
    }

    public override void DeadState()
    {
        enemyTrigger.gameObject.GetComponent<Animator>().SetInteger("State", 4);
        if (enemyTrigger.isDead)
        {
            Destroy(this.gameObject);
        }
    }

    public override void DeadCheck()
    {
        if (enemyCurrentHp <= 0)
        {
            enemyTrigger.monsterState = MonsterState.Dead;

        }
    }
    private void Start()
    {
        SetInitState();
    }
    private void Update()
    {
        base.EnemyMovement(enemyTrigger.monsterState);
    }

}
