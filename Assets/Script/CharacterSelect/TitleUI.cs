using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleUI : MonoBehaviour {

    private bool isEnd = false;
    public Text dragonText;
    public Text dragonAngryText;
    private bool ones = true;
    public void HzR()
    {
        SceneLoader.LoadScene("HzR");
    }
    public void GameStart()
    {
        if (isEnd == false)
        {
            StartCoroutine(DragonFruitAngry(ones));
        }
        else
        {
            SceneLoader.LoadScene("CharacterSelect");
        }
    }
    private IEnumerator DragonFruitAngry(bool check)
    {
        if (check == true)
        {
            ones = false;
            dragonText.gameObject.SetActive(false);
            dragonAngryText.gameObject.SetActive(true);
            dragonAngryText.text = "어이어이, 네녀석, \n설마 설명도 듣지 않을 셈인게냐??";
            yield return new WaitForSeconds(3);
            dragonAngryText.text = "뭐, 좋아. \n가서 열심히 해보라구 \n킄킄킄";
            yield return new WaitForSeconds(2);
            SceneLoader.LoadScene("CharacterSelect");
        }
        
    }
    private float fruitCount = 3;
    private IEnumerator DragonFruit()
    {
        dragonText.text = "안녕, 내 이름은 용과.\n 나이는 커여운 6살";
        yield return new WaitForSeconds(fruitCount);
        dragonText.text = "지금부터 게임을 어떻게 \n시작하는지 알려주도록하지";
        yield return new WaitForSeconds(fruitCount);
        dragonText.text = "그 전에 길고 긴 과일나라의 역사를 설명해주겠다.";
        yield return new WaitForSeconds(fruitCount);
        dragonText.text = "우린 모두 행복하게 살고 있었어";
        yield return new WaitForSeconds(fruitCount);
        dragonText.text = "하지만 어느날 하늘에서 대빵 큰 슬라임이 나타나더니";
        yield return new WaitForSeconds(fruitCount);
        dragonText.text = "과일 칭구들이 이상해져버렸지 뭐야";
        yield return new WaitForSeconds(fruitCount);
        dragonText.text = "슬라임을 없애고 과일친구들을 구해줘";
        yield return new WaitForSeconds(fruitCount);
        dragonText.text = "아 물론 과일나라의 법은 엄격해서";
        yield return new WaitForSeconds(fruitCount);
        dragonText.text = "그들이 선빵을 친다면 너도 쳐도 돼";
        yield return new WaitForSeconds(fruitCount);
        dragonText.text = "만약 네가 먼저 선빵을 친다면...";
        yield return new WaitForSeconds(fruitCount);
        dragonText.text = "근데 상관없어 어쩌피 그녀석들은 과일이니까";
        yield return new WaitForSeconds(fruitCount);
        isEnd = true;
        dragonText.text = "긴 설명 잘 들었다.";
        yield return new WaitForSeconds(fruitCount);
        dragonText.text = "이제 Start버튼을 누르고 게임을 시작하도록";
        yield return new WaitForSeconds(fruitCount);
        dragonText.text = "";
        yield return null;
    }
    private void Start()
    {
        isEnd = false;
        StartCoroutine(DragonFruit());
    }
}
