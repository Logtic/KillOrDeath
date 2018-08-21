using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public static GameController gameController;
    public List<GameObject> spawnEnemyList;
    
    public bool IsEnemyAllDead()
    {
        foreach(GameObject s in spawnEnemyList)
        {
            if (s != null)
                return false;
        }
        return true;
    }

    public IEnumerator CheckAllDead()
    {
        yield return new WaitForSeconds(1);
        if (IsEnemyAllDead())
        {
            UIInGame.UIInstance.canWarp = true;
        }
        yield return null;
    }

    public void BattleCheck()
    {
        StartCoroutine(CheckAllDead());
    }

    private void Start()
    {
        gameController = this;
        Initialization.SetInitializationInGame_Enemy();
    }
}
