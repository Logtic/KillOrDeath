using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour {

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Floor");
            collision.gameObject.GetComponent<PlayerController>().isWall = false;
            collision.gameObject.GetComponent<PlayerController>().PlayerOnTheFloor();
        }
    }
    private void Start()
    {
        Physics2D.IgnoreCollision(GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>(), GetComponent<Collider2D>());
    }
}
