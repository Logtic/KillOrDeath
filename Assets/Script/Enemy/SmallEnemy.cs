using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEnemy : Enemy {
    public SmallEnemyBattleTrigger enemyTrigger;

    public float enemySpeed;
    public bool direction; // false -> left, true -> right

    private bool limitMove;
    
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
        if (direction)
            MoveRight();
        else
            MoveLeft();

        
    }

    public override void ChaseState()
    {
        GameObject player = GameObject.FindWithTag("Player");
        
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
        base.AttackState();
    }
    public override void DeadState()
    {
        base.DeadState();
    }
    private void Start()
    {
        Physics2D.IgnoreCollision(GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
    private void Update()
    {
        base.EnemyMovement(enemyTrigger.monsterState);
    }
    
}
