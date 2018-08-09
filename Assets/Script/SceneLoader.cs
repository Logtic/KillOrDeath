using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
    private static bool sceneLoadSetup = false;
    
    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        /*
        GameObject fadeOutPrefab = Resources.Load("FadeOut") as GameObject;
        GameObject fadeOut = GameObject.Instantiate(fadeOutPrefab, GameObject.Find("Canvas").transform) as GameObject;
        fadeOut.GetComponent<FadeOut>().StartFadeOut(() =>
        {
            SceneManager.LoadScene(sceneName);
        });
        */
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
