using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomatoController : PlayerController {
    public GameObject tomatoSprite;
    public List<Sprite> attackMotion;
    public Sprite Idle;

    private bool isAttack = false;
    private int setSpeed;
    public void Setting()
    {
        isAttack = true;
        setSpeed = player.playerSpeed;
        player.playerSpeed = 0;
    }
    public void AgainSetting()
    {
        isAttack = false;
        player.playerSpeed = setSpeed;
    }

    private bool attacking;
    private IEnumerator Attacking(bool direct)
    {
        
        tomatoSprite.transform.rotation = new Quaternion(0, 0, 0, 0);
        if (direct)
        {
            tomatoSprite.GetComponent<SpriteRenderer>().flipX = false;
            normalAttackEffect.SetActive(true);
            normalAttackEffect.GetComponent<SpriteRenderer>().flipX = true;
            normalAttackEffect.transform.localPosition = new Vector3(0.4f, 0, 0);
        }

        else
        {
            tomatoSprite.GetComponent<SpriteRenderer>().flipX = true;
            normalAttackEffect.SetActive(true);
            normalAttackEffect.GetComponent<SpriteRenderer>().flipX = false;
            normalAttackEffect.transform.localPosition = new Vector3(-0.4f, 0, 0);
        }
        for (int i = 0; i < attackMotion.Count; i++)
            {
                tomatoSprite.GetComponent<SpriteRenderer>().sprite = attackMotion[i];
                
               
            yield return new WaitForSeconds(0.2f);
            }
        attacking = false;
        tomatoSprite.GetComponent<SpriteRenderer>().sprite = Idle;
        AgainSetting();
        normalAttackEffect.SetActive(false);
        //AgainSetting();
        yield return null;
       
    }
    public override void PlayerAttack()
    {
        if (Input.GetButtonDown("NormalAttack") && isAttack == false)
        {
            Setting();
            attacking = true;
            if (attackDirect == true)
            {
                StartCoroutine(Attacking(attackDirect));
                //normalAttackEffect.SetActive(true);

            }
            else
            {
                StartCoroutine(Attacking(attackDirect));
                //normalAttackEffect.SetActive(true);
            }
        }
    }

    private bool isFalling;
    private IEnumerator TomatoFallingDown()
    {
        //this.GetComponent<BoxCollider2D>().isTrigger = true;
        player.gameObject.GetComponent<CircleCollider2D>().isTrigger = true;
        yield return new WaitForSeconds(0.5f);
        //this.GetComponent<BoxCollider2D>().isTrigger = false;
        player.gameObject.GetComponent<CircleCollider2D>().isTrigger = false;
        isFalling = false;
        yield return null;
    }
    public override void PlayerMovement()
    {
        if (Input.GetAxis("Vertical") < 0) // FallDown
        {
            if (Input.GetButtonDown("Jump") && currentJumpCount == 0 && isWall == false)
            {
                isFalling = true;
                StartCoroutine(TomatoFallingDown());
            }
        }
        else if (!isFalling)
        {
            if (Input.GetButtonDown("Jump") && currentJumpCount < player.playerMaxJumpCount) // JumpCheck
            {
                //this.GetComponent<BoxCollider2D>().isTrigger = true;
                player.gameObject.GetComponent<CircleCollider2D>().isTrigger = true;
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, player.playerJump);
                currentJumpCount++;
            }
            if (this.GetComponent<Rigidbody2D>().velocity.y < 0)    //TriggerCheck
            {
                //this.GetComponent<BoxCollider2D>().isTrigger = false;
                player.gameObject.GetComponent<CircleCollider2D>().isTrigger = false;
            }

        }
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * player.playerSpeed;
        
        if (x > 0 && attacking == false)
        {
            tomatoSprite.transform.Rotate(0, 0, -x * 20);
            attackDirect = true;
            tomatoSprite.GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (x < 0 && attacking == false)
        {
            tomatoSprite.transform.Rotate(0, 0, -x * 20);
            attackDirect = false;
            tomatoSprite.GetComponent<SpriteRenderer>().flipX = true;
        }
        transform.Translate(x, 0, 0);

        CameraMoving();

    }

}
