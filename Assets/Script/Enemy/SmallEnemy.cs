using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEnemy : Enemy {
    public SmallEnemyBattleTrigger enemyTrigger;
    
    public bool direction; // false -> left, true -> right

    private bool limitMove;

    public override void SetInitState()
    {
        enemyAtk = 3;
        enemyDef = 3;
        enemySpeed = 0.5f;
        Physics2D.IgnoreCollision(GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
    private void EnemyAttack()
    {
        if (Input.GetButtonDown("Fire3")) // left shift
        {
            Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            if (player.nearEnemy!= null)
                BattleController.AttackEnemyToPlayer(player, this);
        }
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
    private void Start()
    {
        SetInitState();
    }
    private void Update()
    {
        base.EnemyMovement(enemyTrigger.monsterState);
        EnemyAttack();
    }
    
}
