using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
    private static bool sceneLoadSetup = false;
    public static void LoadScene(string sceneName)
    {
        if (GameObject.FindGameObjectWithTag("bgm") != null)
            Destroy(GameObject.FindGameObjectWithTag("bgm"));
        SceneManager.LoadScene(sceneName);
    }
    public static void MapToMap(string mapName)
    {
        PlayerPrefs.SetInt("playerCurrentHp", UIInGame.UIInstance.player.GetComponent<PlayerController>().player.playerCurrentHp);
        DontDestroyOnLoad(GameObject.FindGameObjectWithTag("bgm"));
        SceneManager.LoadScene(mapName);
    }

    

    /*private static void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject fadeInPrefab = Resources.Load("FadeIn") as GameObject;
        GameObject fadeIn = GameObject.Instantiate(fadeInPrefab) as GameObject;
        fadeIn.GetComponent<FadeIn>().StartFadeIn();
    }
    public static void OnSceneLoaded()
    {
        GameObject fadeInPrefab = Resources.Load("FadeIn") as GameObject;
        GameObject fadeIn = GameObject.Instantiate(fadeInPrefab, GameObject.Find("Canvas").transform);
        fadeIn.GetComponent<FadeIn>().StartFadeIn();
    }*/
}
