using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInGame : MonoBehaviour {
   
    public int count;
    public Text text;

    public static UIInGame UIInstance;

    public void CheckEnemyCount()
    {
        count++;
        text.text = count.ToString();
    }
    private void Start()
    {
        UIInstance = this;
        count = 0;
        
         
    }

}
