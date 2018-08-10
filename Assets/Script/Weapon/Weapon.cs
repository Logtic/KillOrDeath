using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour{
    public string weaponName;
    public int weaponAtk;


    public virtual void NormalAttack() { }
    public virtual void ChargeAttack() { }

    public void OnDestroy()
    {
        Destroy(this.gameObject);
    }
}


