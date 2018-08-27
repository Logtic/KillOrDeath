using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingSlimeEnemy : Enemy {
    
    public GameObject slimeMove;
    public GameObject slimeAttack1;
    public GameObject slimeAttack2;
    

    public override void MoveRight()
    {
        this.transform.position = new Vector2(this.transform.position.x + enemySpeed * 0.01f, this.transform.position.y);
        slimeMove.GetComponent<SpriteRenderer>().flipX = true;

    }
    public override void MoveLeft()
    {
        this.transform.position = new Vector2(this.transform.position.x - enemySpeed * 0.01f, this.transform.position.y);
        slimeMove.GetComponent<SpriteRenderer>().flipX = false;
    }

    public void ChasePlayer()
    {
        if (this.transform.position.x > UIInGame.UIInstance.player.transform.position.x)
        {
            MoveLeft();
        }
        else if (this.transform.position.x < UIInGame.UIInstance.player.transform.position.x)
        {
            MoveRight();
        }
    }
    public void Move()
    {
        slimeMove.SetActive(true);
        slimeAttack1.SetActive(false);
        slimeAttack2.SetActive(false);
    }
    public void Attack1()
    {
        slimeMove.SetActive(false);
        slimeAttack1.SetActive(true);
        slimeAttack2.SetActive(false);
    }
    public void Attack2()
    {
        slimeMove.SetActive(false);
        slimeAttack1.SetActive(false);
        slimeAttack2.SetActive(true);
    }
    private IEnumerator KingSlimeControll()
    {
        Move();
        yield return new WaitForSeconds(2);
        for (int i = 0; i < 100; i++)
        {
            ChasePlayer();
            yield return new WaitForSeconds(0.05f);
        }
        Attack1();
        yield return new WaitForSeconds(3.5f);
        Move();
        for (int i = 0; i < 100; i++)
        {
            ChasePlayer();
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(5);
        Attack2();
        yield return new WaitForSeconds(1);
        yield return StartCoroutine(KingSlimeControll());
    }

    public override void SetInitState()
    {
        Physics2D.IgnoreCollision(GameObject.FindGameObjectWithTag("Floor").GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());

        base.SetInitState();
        StartCoroutine(KingSlimeControll());
    }
    public override void DeadState()
    {
        Destroy(this.gameObject);

    }

    public override void DeadCheck()
    {
        if (enemyCurrentHp <= 0)
        {
            DeadState();

        }
    }
    private void Start()
    {
    }
}
