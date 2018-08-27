using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().player.playerCurrentHp = 0;
            collision.gameObject.GetComponent<PlayerController>().PlayerCheckDead();
        }
    }
}
