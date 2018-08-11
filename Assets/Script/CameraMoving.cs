using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour {
    

    private void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        this.GetComponent<Transform>().position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
    }
}
