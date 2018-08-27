using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingSlimeAttack : MonoBehaviour {
    public GameObject attackEffect;

    public void EffectOn()
    {
        attackEffect.SetActive(true);
    }
    public void EffectOff()
    {
        attackEffect.GetComponent<KingSlimeAttackEffect>().attack = false;
        attackEffect.SetActive(false);
    }
}
