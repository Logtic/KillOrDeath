using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

    public bool isBottom;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && isBottom)
        {
            collision.gameObject.GetComponent<PlayerController>().isWall = true;
            collision.gameObject.GetComponent<PlayerController>().PlayerOnTheFloor();
        }
    }
}
