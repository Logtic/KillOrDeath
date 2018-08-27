using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingSlimeAttack2 : MonoBehaviour {

    public GameObject normalSlime;
	
    public void InstantiateNormalSlime()
    {
        GameObject newOne1 = Instantiate(normalSlime);
        newOne1.transform.position = this.gameObject.transform.position + new Vector3(-4, 0, 0);
        GameObject newOne2 = Instantiate(normalSlime);
        newOne2.transform.position = this.gameObject.transform.position + new Vector3(4, 0, 0);
    }
}
