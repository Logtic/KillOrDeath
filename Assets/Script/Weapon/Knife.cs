using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : Weapon {

    private Animation anim;
    
    //public GameObject normalAttackEffect;
    public int reinforce;

    public override void NormalAttack()
    {
        anim.Play(weaponName+"NormalAttack");
        normalAttackEffect.SetActive(true);
        //normalAttackEffect.GetComponent<PlayerAttackEffect>().attack = false;
    }
    public override void NormalAttackDone()
    {
        //normalAttackEffect.GetComponent<PlayerAttackEffect>().attack = false;
        normalAttackEffect.SetActive(false);
    }
    public override void ChargeAttack()
    {
        anim.Play(weaponName + "ChargeAttack");
        chargeAttackEffect.SetActive(true);
        
    }
    private void Start()
    {
        anim = this.GetComponent<Animation>();
    }
}
