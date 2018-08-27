using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbokadoEnemy : Enemy {

    public Sprite idle;
    public Sprite attack;
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
        if (collision.gameObject.tag == "EnemyFloorTrigger" )
        {
            limitMove = false;
        }
    }

    public override void MoveRight()
    {
        this.transform.position = new Vector2(this.transform.position.x + enemySpeed * Time.deltaTime, this.transform.position.y);
        enemyTrigger.gameObject.GetComponent<SpriteRenderer>().flipX = true;
    }
    public override void MoveLeft()
    {
        this.transform.position = new Vector2(this.transform.position.x - enemySpeed * Time.deltaTime, this.transform.position.y);
        enemyTrigger.gameObject.GetComponent<SpriteRenderer>().flipX = false;
    }


    public override void SetInitState()
    {
        attacking = false;
        base.SetInitState();
    }
    
    private IEnumerator Attacking()
    {
        enemyTrigger.gameObject.GetComponent<SpriteRenderer>().sprite = attack;
        yield return new WaitForSeconds(0.5f);
        enemyTrigger.gameObject.GetComponent<SpriteRenderer>().sprite = idle;
        yield return new WaitForSeconds(1);

    }

    public bool attacking;
    public override void ChaseState()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (!limitMove)
        {
            if (player.transform.position.x > this.transform.position.x)
            {
                direction = true;
                MoveRight();
                if (player.transform.position.x < this.transform.position.x + 5)
                {
                    AttackState();
                }
                
            }
            else
            {
                direction = false;
                MoveLeft();
                if (player.transform.position.x > this.transform.position.x - 5)
                    AttackState();
            }
        }
        else
        {
            if (direction == true && player.transform.position.x > this.transform.position.x)
            {
                limitMove = false;
                MoveRight();
                if (player.transform.position.x < this.transform.position.x + 5)
                {
                    AttackState();
                }
            }
            else if (direction == false && player.transform.position.x < this.transform.position.x)
            {
                limitMove = false;
                MoveLeft();
                if (player.transform.position.x > this.transform.position.x - 5)
                    AttackState();
            }
        }
    }
    public override void AttackState()
    {
        // 애니메이션에 끝날 때 endAttack을 true로 놓을 것

        if (enemyTrigger.endAttack) // 공격 후에는 다시 Chase모드로
        {
            enemyTrigger.enemyAttackEffect.GetComponent<EnemyAttackEffect>().attack = false;
            enemyTrigger.monsterState = MonsterState.Chase;
            enemyTrigger.endAttack = false;
            attacking = false;

        }
        else
        {
            
           
            if (direction && attacking == false) // 오른쪽으로 공격
            {
                enemyTrigger.gameObject.GetComponent<SpriteRenderer>().flipX = true;
                enemyTrigger.enemyAttackEffect.SetActive(true);
                StartCoroutine(Attacking());
                enemyTrigger.enemyAttackEffect.GetComponent<Animator>().SetBool("direct", true);
                attacking = true;
            }
            else if (!direction && attacking == false) // 왼쪽으로 공격
            {
                enemyTrigger.gameObject.GetComponent<SpriteRenderer>().flipX = false;
                enemyTrigger.enemyAttackEffect.SetActive(true);
                StartCoroutine(Attacking());
                enemyTrigger.enemyAttackEffect.GetComponent<Animator>().SetBool("direct", false);
                attacking = true;
            }

        }
    }

    public override void DeadState()
    {
            Destroy(this.gameObject);
       
    }

    public override void DeadCheck()
    {
        if (enemyCurrentHp <= 0)
        {
            enemyTrigger.monsterState = MonsterState.Dead;

        }
    }
    private void Update()
    {
        base.EnemyMovement(enemyTrigger.monsterState);
    }

}
