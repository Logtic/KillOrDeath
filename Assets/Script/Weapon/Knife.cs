using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : Weapon {

    private Animation anim;
    public AnimationClip normalAttack;
    
    //public GameObject normalAttackEffect;
    public int reinforce;

    public override void NormalAttack()
    {
        anim.Play("knife_normal");
        //Instantiate(normalAttackEffect);
    }
    private void Start()
    {
        anim = this.GetComponent<Animation>();
    }
}
