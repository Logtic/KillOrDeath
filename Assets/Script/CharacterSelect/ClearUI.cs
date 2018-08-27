using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearUI : MonoBehaviour {
    public Text text, text2;
    public Image image;
    public GameObject destiny;
    public GameObject button;
    public Sprite yong, mawang;

    public void GoToTitle()
    {
        SceneLoader.LoadScene("Title");
    }
    private void Start()
    {
        StartCoroutine(Clear());
    }
    private IEnumerator Clear()
    {
        text.text = "과일나라를 구해줘서 고마워";
        yield return new WaitForSeconds(3);
        text.text = "덕분에 골칫덩이를 해결할 수 있었어";
        yield return new WaitForSeconds(3);
        text.text = "킄킄킄..어리석은 것...";
        for (int i = 0; i < 3; i++)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 1 - 0.3f * i);
            yield return new WaitForSeconds(1);
        }
        image.sprite = mawang;
        for (int i = 0; i < 3; i++)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0.3f * i);
            yield return new WaitForSeconds(1);
        }
        image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
        text.text = "이젠 내가 마왕이다!!";
        yield return new WaitForSeconds(3);
        destiny.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        text2.text = "과연 과일 나라의 운명은?!";
        yield return new WaitForSeconds(2);
        button.SetActive(true);
        yield return null;

    }
}
