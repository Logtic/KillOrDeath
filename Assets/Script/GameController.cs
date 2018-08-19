using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public static GameController gameController;
    public List<GameObject> spawnWeaponList;
    public List<GameObject> spawnEnemyList;
    
    public GameObject FindWeaponObject(string weaponName)
    {
        foreach(GameObject w in spawnWeaponList)
        {
            if (w.GetComponent<Weapon>().weaponName == weaponName)
                return w;
        }
        return null;
    }

    private void Start()
    {
        gameController = this;
        Initialization.SetInitializationInGame_Enemy();
    }
}
