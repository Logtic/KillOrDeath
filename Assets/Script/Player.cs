using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Weapon playerWeapon;
    public int playerSpeed;
    public int playerJump;

    private void PlayerAttack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            this.transform.GetChild(0).GetComponent<Weapon>().NormalAttack();
        }
    }
    private void PlayerMovement()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * playerSpeed;
        transform.Translate(x, 0, 0);
        if (Input.GetKeyDown("space"))
        {
            this.GetComponent<BoxCollider2D>().isTrigger = true;
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, playerJump); 
        }
        if (this.GetComponent<Rigidbody2D>().velocity.y < 0)
            this.GetComponent<BoxCollider2D>().isTrigger = false;
        
    }
    private void Start()
    {
        Instantiate(playerWeapon.gameObject, this.transform);
    }

    private void Update()
    {
        PlayerMovement();
        PlayerAttack();
    }
    
}
