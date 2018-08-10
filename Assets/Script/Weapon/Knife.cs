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
        //Instantiate(normalAttackEffect);
    }
    public override void ChargeAttack()
    {
        anim.Play(weaponName + "ChargeAttack");
    }
    private void Start()
    {
        anim = this.GetComponent<Animation>();
    }
}
