﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleEnemy : Enemy {
    public Sprite idle1, idle2;
    public Sprite attack1, attack2, attack3, attack4, attack5, attack6;
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

    private IEnumerator Walking()
    {
        enemyTrigger.gameObject.GetComponent<SpriteRenderer>().sprite = idle1;
        yield return new WaitForSeconds(0.5f);

        enemyTrigger.gameObject.GetComponent<SpriteRenderer>().sprite = idle2;
        yield return new WaitForSeconds(0.5f);


    }

    private IEnumerator Attacking(bool direct)
    {
        attacking = true;
        float speed = enemySpeed;

        enemySpeed = 0;
        
        enemyTrigger.gameObject.GetComponent<SpriteRenderer>().sprite = attack1;
        yield return new WaitForSeconds(0.1f);
        enemyTrigger.gameObject.GetComponent<SpriteRenderer>().sprite = attack2;
        yield return new WaitForSeconds(0.1f);
        enemyTrigger.gameObject.GetComponent<SpriteRenderer>().sprite = attack3;
        yield return new WaitForSeconds(0.1f);
        enemyTrigger.gameObject.GetComponent<SpriteRenderer>().sprite = attack4;
        yield return new WaitForSeconds(0.1f);
        Debug.Log(enemyAtk);
        enemyTrigger.gameObject.GetComponent<SpriteRenderer>().sprite = attack5;
        
        yield return new WaitForSeconds(0.5f);

        if (direct)
        {
            enemyTrigger.enemyAttackEffect.SetActive(true);
            enemyTrigger.enemyAttackEffect.GetComponent<SpriteRenderer>().flipX = true;
            enemyTrigger.enemyAttackEffect.transform.localPosition = new Vector3(3.5f, 0, 0);
        }
        else
        {

            enemyTrigger.enemyAttackEffect.SetActive(true);
            enemyTrigger.enemyAttackEffect.GetComponent<SpriteRenderer>().flipX = false;
            enemyTrigger.enemyAttackEffect.transform.localPosition = new Vector3(-3.5f, 0, 0);
        }
        enemyTrigger.gameObject.GetComponent<SpriteRenderer>().sprite = attack6;
        yield return new WaitForSeconds(0.5f);

        enemySpeed = speed;
        enemyTrigger.gameObject.GetComponent<SpriteRenderer>().sprite = idle1;
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
                if (player.transform.position.x < this.transform.position.x + 2)
                {
                    AttackState();
                }

            }
            else
            {
                direction = false;
                MoveLeft();
                if (player.transform.position.x > this.transform.position.x - 2)
                    AttackState();
            }
        }
        else
        {
            if (direction == true && player.transform.position.x > this.transform.position.x)
            {
                limitMove = false;
                MoveRight();
                if (player.transform.position.x < this.transform.position.x + 2)
                {
                    AttackState();
                }
            }
            else if (direction == false && player.transform.position.x < this.transform.position.x)
            {
                limitMove = false;
                MoveLeft();
                if (player.transform.position.x > this.transform.position.x - 2)
                    AttackState();
            }
        }
    }
    public override void AttackState()
    {
        // 애니메이션에 끝날 때 endAttack을 true로 놓을 것
        enemyTrigger.monsterState = MonsterState.Attack;
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
                StartCoroutine(Attacking(true));
            }
            else if (!direction && attacking == false) // 왼쪽으로 공격
            {
                enemyTrigger.gameObject.GetComponent<SpriteRenderer>().flipX = true;
                StartCoroutine(Attacking(false));
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