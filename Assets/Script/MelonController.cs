using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelonController : PlayerController {
    
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

    private bool isAttack = false;

    public void PlayerAttackSound()
    {
        source.PlayOneShot(AttackSound);
    }
    public override void PlayerAttack()
    {
        if (Input.GetButtonDown("NormalAttack") && isAttack == false)
        {
            Setting();
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
