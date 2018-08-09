using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Weapon playerWeapon;

    public int playerAtk;
    public int playerDef;
    public int playerMaxHp;
    public int playerCurrentHp;

    public int playerSpeed;
    public int playerJump;
    public int playerMaxJumpCount;
    private int currentJumpCount;
    public void PlayerOnTheFloor()
    {
        currentJumpCount = 0;
    }

    private void PlayerAttack()
    {
        if (Input.GetButtonDown("Fire1")) // Ctrl
        {
            this.transform.GetChild(0).GetComponent<Weapon>().NormalAttack();
            
            
        }
    }
    private void PlayerMovement()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * playerSpeed;
        transform.Translate(x, 0, 0);

        if (Input.GetKeyDown("space") && currentJumpCount < playerMaxJumpCount) // JumpCheck
        {
            this.GetComponent<BoxCollider2D>().isTrigger = true;
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, playerJump);
            currentJumpCount++;
        }
        if (this.GetComponent<Rigidbody2D>().velocity.y < 0)    //TriggerCheck
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
