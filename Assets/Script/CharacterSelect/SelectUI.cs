using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectUI : MonoBehaviour {

    public static SelectUI selectUI;

    public PlayerType player;

    public GameObject Tomato;
    public GameObject Lemon;
    public GameObject Melon;

    public void SelectPlayer(PlayerType playerType)
    {
        player = playerType;
        if (playerType == PlayerType.Tomato)
        {
            Tomato.GetComponent<Image>().color = Color.black;
            Lemon.GetComponent<Image>().color = Color.white;
            Melon.GetComponent<Image>().color = Color.white;
        }
        else if (playerType == PlayerType.Lemon)
        {
            Tomato.GetComponent<Image>().color = Color.white;
            Lemon.GetComponent<Image>().color = Color.black;
            Melon.GetComponent<Image>().color = Color.white;
        }
        else if (playerType == PlayerType.Melon)
        {
            Tomato.GetComponent<Image>().color = Color.white;
            Lemon.GetComponent<Image>().color = Color.white;
            Melon.GetComponent<Image>().color = Color.black;
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
        SceneLoader.LoadScene("testMode");
    }

    private void Start()
    {
        selectUI = this;
    }
}
