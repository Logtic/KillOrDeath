using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
    public GameObject fadeOut;

    private IEnumerator GameOverPanelDestroy()
    {
        fadeOut.SetActive(true);
        for (int i = 0; i < 5; i++)
        {
            fadeOut.GetComponent<Image>().color = new Color(0, 0, 0, i * 0.2f);
            yield return new WaitForSeconds(0.5f);
        }
        SceneLoader.LoadScene("Title");
        yield return null;
    }
    private void Start()
    {
        StartCoroutine(GameOverPanelDestroy());
    }
}
