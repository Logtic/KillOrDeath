using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalSlimeEnemy : Enemy {
    public Sprite idle;
    public List<Sprite> attack;
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

    public override void MoveRight()
    {
        this.transform.position = new Vector2(this.transform.position.x + enemySpeed * Time.deltaTime, this.transform.position.y);
        enemyTrigger.gameObject.GetComponent<SpriteRenderer>().flipX = false;

    }
    public override void MoveLeft()
    {
        this.transform.position = new Vector2(this.transform.position.x - enemySpeed * Time.deltaTime, this.transform.position.y);
        enemyTrigger.gameObject.GetComponent<SpriteRenderer>().flipX = true;

    }


    public override void SetInitState()
    {
        attacking = false;
        base.SetInitState();
    }
    

    private IEnumerator Attacking()
    {
        float speed = enemySpeed;

        enemySpeed = 0;

        attacking = true;
        for (int i = 0; i < 15; i++)
        {
            enemyTrigger.gameObject.GetComponent<SpriteRenderer>().sprite = attack[i];
            if (i == 12)
            {
                if (direction)
                {
                    enemyTrigger.enemyAttackEffect.SetActive(true);
                    enemyTrigger.enemyAttackEffect.transform.localPosition = new Vector3(2, -1, 0);
                }
                else
                {
                    enemyTrigger.enemyAttackEffect.SetActive(true);
                    enemyTrigger.enemyAttackEffect.transform.localPosition = new Vector3(-2, -1, 0);
                }
            }
            yield return new WaitForSeconds(0.1f);
        }
        enemySpeed = speed;
        enemyTrigger.gameObject.GetComponent<SpriteRenderer>().sprite = idle;
        enemyTrigger.enemyAttackEffect.GetComponent<EnemyAttackEffect>().DisableEffect();
        yield return null;
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
    public override void AttackState()
    {
        // 애니메이션에 끝날 때 endAttack을 true로 놓을 것

        if (enemyTrigger.endAttack) // 공격 후에는 다시 Chase모드로
        {
            enemyTrigger.enemyAttackEffect.GetComponent<EnemyAttackEffect>().attack = false;
            enemyTrigger.enemyAttackEffect.SetActive(false);
            enemyTrigger.monsterState = MonsterState.Chase;
            enemyTrigger.endAttack = false;
            attacking = false;

        }
        else
        {
            if (direction && attacking == false) // 오른쪽으로 공격
            {
                enemyTrigger.gameObject.GetComponent<SpriteRenderer>().flipX = false;
                StartCoroutine(Attacking());
            }
            else if (!direction && attacking == false) // 왼쪽으로 공격
            {
                enemyTrigger.gameObject.GetComponent<SpriteRenderer>().flipX = true;
                StartCoroutine(Attacking());
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
