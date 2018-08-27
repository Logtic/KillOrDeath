using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HzR : MonoBehaviour {
    public Text text1, text2;

    private void Start()
    {
        text1.text = "경기 게임 영재 캠프\n 조 이름 : HzR\n 천준희, 송민성, 최강민,우시영,박희민,최민석\n";
        text2.text = "조장 - 우시영 : 로그라이크 좋아용 \n박희민 : 메이플 200찍음 \n송민성 : 쌤쌤쌤쌤쌤쌤쌤쌤쌤쌤쌤\n" +
            "천준희 : 메이플M합시다 \n최강민 : 도호쿠키린탄뎃숭 \n최민석 : 팀 내의 귀여움을 담당합니다.";
    }

    public void GoToTitle()
    {
        SceneLoader.LoadScene("Title");
    }
}
