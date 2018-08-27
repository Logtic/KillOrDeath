using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapeController : PlayerController {
    public Sprite idleState;
    public Sprite attackState;
    
    private IEnumerator Attacking()
    {
        this.GetComponent<SpriteRenderer>().sprite = attackState;
        yield return new WaitForSeconds(0.5f);
        this.GetComponent<SpriteRenderer>().sprite = idleState;
        yield return null;
    }
    public override void PlayerAttack()
    {
        if (Input.GetButtonDown("NormalAttack") && attacking == false)
        {
            source.PlayOneShot(AttackSound);
            attacking = true;
            StartCoroutine(Attacking());
            if (attackDirect == true)
            {
                normalAttackEffect.SetActive(true);
                normalAttackEffect.GetComponent<Animator>().SetBool("direct", false);
            }
            else
            {
                normalAttackEffect.SetActive(true);
                normalAttackEffect.GetComponent<Animator>().SetBool("direct", true);
            }
        }

    }

    public override void PlayerMovement()
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
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (x < 0)
        {
            attackDirect = false;
            this.GetComponent<SpriteRenderer>().flipX = false; 
        }
        transform.Translate(x, 0, 0);

        if (UIInGame.UIInstance.isWarping == false)
            CameraMoving();

    }
}
