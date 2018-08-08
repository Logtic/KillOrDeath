using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Move : NetworkBehaviour {
    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    void Fire()
    {
        var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

        bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.forward * 6;
        Destroy(bullet, 2.0f);
    }

    void Update()
    {
        if (!isLocalPlayer) {
            return;
        }
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 10.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 10.0f;

        transform.Translate(x, 0, 0);
        transform.Translate(0, z, 0);

        if (Input.GetKeyDown(KeyCode.Space))
            Fire();
    }
}
