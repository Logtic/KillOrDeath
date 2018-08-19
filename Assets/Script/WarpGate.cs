using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpGate : MonoBehaviour {
    public bool canWarp;
    public string sceneName;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (canWarp)
            {
                SceneLoader.LoadScene(sceneName);
            }
        }
    }
}
