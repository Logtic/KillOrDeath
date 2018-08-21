using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelonController : PlayerController {
    
    private int setJump;
    private int setSpeed;

    public void Setting()
    {
        setJump = player.playerJump;
        setSpeed = player.playerSpeed;
    }
    public void AgainSetting()
    {
        Debug.Log(setJump);
        player.playerJump = setJump;
        player.playerSpeed = setSpeed;
    }

    public override void PlayerAttack()
    {
        if (Input.GetButtonDown("NormalAttack") && currentJumpCount == 0)
        {
            Setting();
            player.playerJump = 0;
            player.playerSpeed = 0;
            if (attackDirect == true)
            {
                normalAttackEffect.SetActive(true);
                normalAttackEffect.GetComponent<SpriteRenderer>().flipX = false;
                StartCoroutine(normalAttackEffect.GetComponent<MelonAttackEffect>().Attacking(attackDirect));
            }
            else
            {
                normalAttackEffect.SetActive(true);
                normalAttackEffect.GetComponent<SpriteRenderer>().flipX = true;
                StartCoroutine(normalAttackEffect.GetComponent<MelonAttackEffect>().Attacking(attackDirect));
            }
        }

    }

    public override void PlayerMovement()
    {
        base.PlayerMovement();
    }
}
