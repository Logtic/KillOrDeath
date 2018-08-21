using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    public Player player;

    public GameObject normalAttackEffect;
    protected int currentJumpCount=0;
    
    public void PlayerOnTheFloor()
    {
        currentJumpCount = 0;
    }

    protected bool attackDirect;
    public virtual void PlayerAttack()
    {
        if (Input.GetButtonDown("NormalAttack"))
        {
            if (attackDirect == true)
            {
                normalAttackEffect.SetActive(true);
                normalAttackEffect.GetComponent<Animator>().SetBool("direct", true);
            }
            else
            {
                normalAttackEffect.SetActive(true);
                normalAttackEffect.GetComponent<Animator>().SetBool("direct", false);
            }
        }
    }

    protected void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            player.gameObject.GetComponent<Collider2D>().isTrigger = false;
        }
    }

    protected IEnumerator FallingDown()
    {
        //this.GetComponent<BoxCollider2D>().isTrigger = true;
        player.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        yield return new WaitForSeconds(0.3f);
        //this.GetComponent<BoxCollider2D>().isTrigger = false;
        player.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        
        yield return null;
    }

    protected void CameraMoving()
    {
        float x, y;
        //mapSize/2-9, mapSize/2-5까지
        if (this.transform.position.x < UIInGame.UIInstance.mapSize.x / 2 - 9 && this.transform.position.x > -(UIInGame.UIInstance.mapSize.x/2-9))
            x = this.transform.position.x;
        else if (this.transform.position.x > UIInGame.UIInstance.mapSize.x / 2 - 9)
            x = UIInGame.UIInstance.mapSize.x / 2 - 9;
        else
            x = -(UIInGame.UIInstance.mapSize.x / 2 - 9);

        if (this.transform.position.y < UIInGame.UIInstance.mapSize.y / 2 - 5 && this.transform.position.y > -(UIInGame.UIInstance.mapSize.y / 2 - 5))
            y = this.transform.position.y;
        else if (this.transform.position.y > UIInGame.UIInstance.mapSize.y / 2 - 5)
            y = UIInGame.UIInstance.mapSize.y/2 - 5;
        else
            y = -(UIInGame.UIInstance.mapSize.y / 2 - 5);
        Camera.main.transform.position = new Vector3(x, y, -10);
    }
    public bool isWall = false;
    public virtual void PlayerMovement() // 움직임 우선순위 정하기
    {
        if (Input.GetAxis("Vertical") < 0) // FallDown
        {
            if (Input.GetButtonDown("Jump") && currentJumpCount == 0 && isWall == false)
            {
                StartCoroutine(FallingDown());
            }
        }
        else
        {
            
            if (Input.GetButtonDown("Jump") && currentJumpCount < player.playerMaxJumpCount) // JumpCheck
            {
                //this.GetComponent<BoxCollider2D>().isTrigger = true;

                player.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, player.playerJump);
                currentJumpCount++;
            }
            if (this.GetComponent<Rigidbody2D>().velocity.y < 0)    //TriggerCheck
            {
                //this.GetComponent<BoxCollider2D>().isTrigger = false;
                player.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
            }
            
        }
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * player.playerSpeed;
        if (x > 0)
        {
            attackDirect = true;
            this.GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (x < 0)
        {
            attackDirect = false;
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
        transform.Translate(x, 0, 0);

        if (UIInGame.UIInstance.isWarping == false)
            CameraMoving();
        
        
    }

    public void PlayerCheckDead()
    {
        if (player.playerCurrentHp <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void SetInit()
    {
        attackDirect = true;
    }

    private void Update()
    {
        PlayerMovement();
        PlayerAttack();
    }

}
