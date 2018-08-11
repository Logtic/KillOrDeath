using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEnemy : Enemy {
    public SmallEnemyBattleTrigger enemyTrigger;

    public Animation enemyAnim;
    
    public bool direction; // false -> left, true -> right

    private bool limitMove;
    
    public override void SetInitState() //초기상태로 만들어라
    {
        attacking = false;
        Physics2D.IgnoreCollision(GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>(), GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(GameObject.FindGameObjectWithTag("Enemy").GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
    private void OnTriggerEnter2D(Collider2D collision) //트리거를 만났을때
    {
        if (collision.gameObject.tag == "EnemyFloorTrigger")
        {
            
            direction = !direction;
            limitMove = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision) //틜거랑 덜어졋을때
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
        // 애니메이션에 끝날 때 endAttack을 true로 놓을 것
        if (direction && attacking == false) // 오른쪽으로 공격
        {
            attacking = true;
            enemyAnim.Play(enemyName + "AttackToRight");
        }
        else if (!direction && attacking == false) // 왼쪽으로 공격
        {
            attacking = true;
            enemyAnim.Play(enemyName + "AttackToLeft");
        }
            
        if (enemyTrigger.endAttack) // 공격 후에는 다시 Chase모드로
        {
            enemyTrigger.endAttack = false;
            attacking = false;
            enemyTrigger.monsterState = MonsterState.Chase;
        }
    }

    public override void DeadState()
    {
        enemyAnim.Play(enemyName + "Dead"); // 애니메이션에 끝날때 isDead를 true로 놓을 것
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
