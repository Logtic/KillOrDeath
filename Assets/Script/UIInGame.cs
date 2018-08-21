using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInGame : MonoBehaviour {
    public Vector2 mapSize; // 1 : 100 비율  카메라 크기 9, 5
    public GameObject player;

    public GameObject Tomato;
    public GameObject Lemon;
    public GameObject Melon;

    public PlayerUI playerUI;
    public GameObject enemyUI;

    public static UIInGame UIInstance;
    public string nextSceneName;

    public GameObject warpGate1, warpGate2, warpGate3, warpGate4;

    public bool canWarp;
    public bool isWarping;
    

    private void Start()
    {
        UIInstance = this;
        if (PlayerPrefs.GetString("player") == "Tomato")
            player = Instantiate(Tomato);
        else if (PlayerPrefs.GetString("player") == "Lemon")
            player = Instantiate(Lemon);
        else if (PlayerPrefs.GetString("player") == "Melon")
            player = Instantiate(Melon);
       
        Initialization.SetInitializationInGame_Player(player.GetComponent<PlayerController>(), playerUI);
        
    }
    private IEnumerator WarpCameraMove(Vector3 distance)
    {
        player.GetComponent<PlayerController>().player.playerSpeed = 0;
        player.GetComponent<PlayerController>().player.playerJump = 0;
        for (int i = 0; i < 30; i++)
        {
            Camera.main.orthographicSize = (5.0f - i * 0.1f);
            Camera.main.transform.position += new Vector3(distance.x / 30, distance.y / 30, -10);
            
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(0.5f);
        SceneLoader.LoadScene(nextSceneName);
        yield return null;
    }
    public void WarpOtherScene()
    {
        StartCoroutine(WarpCameraMove(player.transform.position - Camera.main.transform.position));
    }
}
