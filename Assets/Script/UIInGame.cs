using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInGame : MonoBehaviour {
    public Vector2 mapSize; // 1 : 100 비율  카메라 크기 9, 5
    public GameObject player;

    public GameObject Tomato;
    public GameObject Lemon;
    public GameObject Grape;
    public GameObject Melon;

    public PlayerUI playerUI;
    public GameObject enemyUI;

    public static UIInGame UIInstance;

    public GameObject warpGate1, warpGate2, warpGate3, warpGate4;

    public GameObject gameClear, gameOver;

    public bool canWarp;
    public bool isWarping;
    public string nextSceneName;
    public void WarpOpen()
    {
        if (warpGate1 != null)
            warpGate1.GetComponent<SpriteRenderer>().sprite = warpGate1.GetComponent<WarpGate>().open;
        if (warpGate2 != null)
            warpGate2.GetComponent<SpriteRenderer>().sprite = warpGate2.GetComponent<WarpGate>().open;
        if (warpGate3 != null)
            warpGate3.GetComponent<SpriteRenderer>().sprite = warpGate3.GetComponent<WarpGate>().open;
        if (warpGate4 != null)
            warpGate4.GetComponent<SpriteRenderer>().sprite = warpGate4.GetComponent<WarpGate>().open;
    }

    private void Start()
    {
        UIInstance = this;
        if (PlayerPrefs.GetString("player") == "Tomato")
            player = Instantiate(Tomato);
        else if (PlayerPrefs.GetString("player") == "Lemon")
            player = Instantiate(Lemon);
        else if (PlayerPrefs.GetString("player") == "Melon")
            player = Instantiate(Melon);
        else if (PlayerPrefs.GetString("player") == "Grape")
            player = Instantiate(Grape);
        if (PlayerPrefs.GetInt("warpGate") == 1)
            player.transform.position = warpGate1.transform.position + new Vector3(0, 1, 0);
        else if (PlayerPrefs.GetInt("warpGate") == 2)
            player.transform.position = warpGate2.transform.position + new Vector3(0, 1, 0);
        else if (PlayerPrefs.GetInt("warpGate") == 3)
            player.transform.position = warpGate3.transform.position + new Vector3(0, 1, 0);
        else if (PlayerPrefs.GetInt("warpGate") == 4)
            player.transform.position = warpGate4.transform.position + new Vector3(0, 1, 0);
        if (PlayerPrefs.GetInt("playerCurrentHp") == -1)
        {
            player.GetComponent<PlayerController>().player.playerCurrentHp = player.GetComponent<PlayerController>().player.playerMaxHp;
        }
        else
        {
            player.GetComponent<PlayerController>().player.playerCurrentHp = PlayerPrefs.GetInt("playerCurrentHp");
        }
        
        
        Initialization.SetInitializationInGame_Player(player.GetComponent<PlayerController>(), playerUI);
        Initialization.SetInitializationInGame_Enemy();

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
        SceneLoader.MapToMap(nextSceneName);
        yield return null;
    }
    public void WarpOtherScene()
    {
        StartCoroutine(WarpCameraMove(player.transform.position - Camera.main.transform.position));
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
    }
    public void GameClear()
    {
        gameClear.SetActive(true);
    }
}
