using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initialization : MonoBehaviour {
    public static void SetInitializationInGame_Player(PlayerController playerController, PlayerUI playerUI)
    {
        playerController.SetInit();
        playerUI.SetInit(playerController);
    }

    public static void SetInitializationInGame_Enemy()
    {
       
        foreach(GameObject enemy in GameController.gameController.spawnEnemyList)
        {
            enemy.GetComponent<Enemy>().SetInitState();
            GameObject newEnemyUI = Instantiate(UIInGame.UIInstance.enemyUI, GameObject.Find("Canvas").transform);
            newEnemyUI.GetComponent<EnemyUI>().SetInit(enemy.GetComponent<Enemy>());
            Debug.Log("NewOne");
        }
    }
}
