using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour{
    public GameObject normalAttackEffect;
    public GameObject chargeAttackEffect;

    public string weaponName;
    public int weaponAtk;
    public bool endAttack = false;

    public virtual void NormalAttack() { }
    public virtual void NormalAttackDone() { }
    public virtual void ChargeAttack() { }
    public virtual void ChargeAttackDone() { }

    public void OnDestroy()
    {
        Destroy(this.gameObject);
    }
}


