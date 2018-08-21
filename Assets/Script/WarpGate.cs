using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpGate : MonoBehaviour {
    public bool canWarp;
    public string sceneName;

    public int gateNum;

    public Sprite close;
    public Sprite open;

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetAxis("Vertical")>0 && UIInGame.UIInstance.isWarping == false && UIInGame.UIInstance.canWarp == true)
            {
                if (gateNum == 1)
                {
                    PlayerPrefs.SetInt("warpGate", 3);
                }
                else if (gateNum == 2)
                {
                    PlayerPrefs.SetInt("warpGate", 4);
                }
                else if (gateNum == 3)
                {
                    PlayerPrefs.SetInt("warpGate", 1);
                }
                else if (gateNum == 4)
                {
                    PlayerPrefs.SetInt("warpGate", 2);
                }
                UIInGame.UIInstance.isWarping = true;
                UIInGame.UIInstance.WarpOtherScene();
            }
            
        }
    }
}
