using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInGame : MonoBehaviour {
    public Vector2 mapSize; // 1 : 100 비율  카메라 크기 9, 5
    public PlayerController playerController;
    public PlayerUI playerUI;
    public GameObject enemyUI;

    public static UIInGame UIInstance;
    

    private void Start()
    {
        UIInstance = this;
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        Initialization.SetInitializationInGame_Player(playerController, playerUI);
        
    }

}
