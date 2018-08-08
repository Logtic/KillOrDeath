using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : Weapon {

    private Animation anim;
    public AnimationClip normalAttack;


    public int atk;
    public int dfs;
    public int speed;
    public int jump;

    public int reinforce;

    public override void NormalAttack()
    {
        anim.Play("knife_normal");
    }
    void Reinforce()
    {
        atk = (int)(atk * (1 + reinforce * 0.2f));
        dfs = (int)(dfs * (1 + reinforce * 0.2f));
        speed = (int)(speed * (1 + reinforce * 0.2f));
        jump = (int)(jump * (1 + reinforce * 0.2f));
    }
    private void Start()
    {
        anim = this.GetComponent<Animation>();
    }
}
