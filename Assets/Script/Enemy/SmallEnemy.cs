using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEnemy : Enemy {
    public SmallEnemyBattleTrigger enemyTrigger;

    public Animation enemyAnim;
    
    public bool direction; // false -> left, true -> right

    private bool limitMove;
    
    public override void SetInitState()
    {
        attacking = false;
        Physics2D.IgnoreCollision(GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyFloorTrigger")
        {
            
            direction = !direction;
            limitMove = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyFloorTrigger")
        {
            limitMove = false;
        }
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
        enemyAnim.Play(enemyName + "Idle");
        if (direction)
            MoveRight();
        else
            MoveLeft();
        

    }

    public override void ChaseState()
    {
        GameObject player = GameObject.FindWithTag("Player");
        enemyAnim.Play(enemyName + "Idle");
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

    private bool attacking;
    public override void AttackState()
    {
        if (direction && attacking == false)
        {
            attacking = true;
            enemyAnim.Play(enemyName + "AttackToRight");
        }
        else if (!direction && attacking == false)
        {
            attacking = true;
            enemyAnim.Play(enemyName + "AttackToLeft");
        }
            
        if (enemyTrigger.endAttack)
        {
            enemyTrigger.endAttack = false;
            attacking = false;
            enemyTrigger.monsterState = MonsterState.Chase;
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
