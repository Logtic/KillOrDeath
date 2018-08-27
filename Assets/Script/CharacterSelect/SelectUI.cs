using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectUI : MonoBehaviour {

    public static SelectUI selectUI;
    public GameObject source;
    public PlayerType player;

    public GameObject Tomato;
    public GameObject Lemon;
    public GameObject Melon;
    public GameObject Grape;

    public void SelectPlayer(PlayerType playerType)
    {
        player = playerType;
        if (playerType == PlayerType.Tomato)
        {
            Tomato.GetComponent<Image>().color = Color.black;
            Lemon.GetComponent<Image>().color = Color.white;
            Melon.GetComponent<Image>().color = Color.white;
            Grape.GetComponent<Image>().color = Color.white;
        }
        else if (playerType == PlayerType.Lemon)
        {
            Tomato.GetComponent<Image>().color = Color.white;
            Lemon.GetComponent<Image>().color = Color.black;
            Melon.GetComponent<Image>().color = Color.white;
            Grape.GetComponent<Image>().color = Color.white;
        }
        else if (playerType == PlayerType.Grape)
        {
            Tomato.GetComponent<Image>().color = Color.white;
            Lemon.GetComponent<Image>().color = Color.white;
            Melon.GetComponent<Image>().color = Color.white;
            Grape.GetComponent<Image>().color = Color.black;
        }
        else if (playerType == PlayerType.Melon)
        {
            Tomato.GetComponent<Image>().color = Color.white;
            Lemon.GetComponent<Image>().color = Color.white;
            Melon.GetComponent<Image>().color = Color.black;
            Grape.GetComponent<Image>().color = Color.white;
        }
        
    }

    public void GameStart()
    {
        string str;
        if (player == PlayerType.Tomato)
            str = "Tomato";
        else if (player == PlayerType.Lemon)
            str = "Lemon";
        else if (player == PlayerType.Melon)
            str = "Melon";
        else 
            str = "Grape";
        PlayerPrefs.SetString("player", str);
        PlayerPrefs.SetInt("warpGate", 3);
        PlayerPrefs.SetInt("playerCurrentHp", -1);
        source.SetActive(true);
        DontDestroyOnLoad(source);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Map1");
    }

    private void Start()
    {
        selectUI = this;
    }
}
