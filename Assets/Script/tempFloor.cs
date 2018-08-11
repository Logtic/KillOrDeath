using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempFloor : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision) //트리거를 만났을때
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Transform>().position = new Vector3(0, -44, 0);
        }
    }
}
