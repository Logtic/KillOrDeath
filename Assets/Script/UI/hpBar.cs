using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpBar : MonoBehaviour {
    
    public Slider hp;
    public int maxHp;
    public int cHp;

    private void Start()
    {
        hp.maxValue = maxHp;
        hp.value = cHp;
    }

    private void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            cHp -= 1;
            hp.value = cHp;
        }
        if (Input.GetKeyDown("d"))
        {
            cHp -= 2;
            hp.value = cHp;
        }
        if (Input.GetKeyDown("h"))
        {
            cHp += 3;
            hp.value = cHp;
        }
    }
}
