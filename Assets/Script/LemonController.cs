using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LemonController : PlayerController
{
    public Sprite idleState;
    public Sprite attackState;

    private IEnumerator Attacking()
    {
        this.GetComponent<SpriteRenderer>().sprite = attackState;
        yield return new WaitForSeconds(1.0f);
        this.GetComponent<SpriteRenderer>().sprite = idleState;
        yield return null;
    }
    public override void PlayerAttack()
    {
        if (Input.GetButtonDown("NormalAttack"))
        {
            StartCoroutine(Attacking());
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

    public override void PlayerMovement()
    {
        base.PlayerMovement();
    }
}
