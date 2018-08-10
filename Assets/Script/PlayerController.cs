using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject playerWeapon;

    public Player player;
    private int currentJumpCount=0;
    
    public void ChangeWeapon(GameObject weapon) // weapon = DropedItem
    {
        if (Input.GetKeyDown("left alt"))
        {
            Debug.Log("left alt");
            GameObject newWeapon = GameController.gameController.FindWeaponObject(weapon.GetComponent<DropedItem>().itemName); // newWeapon = Weapon
            playerWeapon.GetComponent<Weapon>().OnDestroy(); // Destroy origin weapon

            playerWeapon = weapon;
            player.playerWeapon = weapon.GetComponent<DropedItem>().itemName; // Change weapon

            GameObject changedWeapon = Instantiate(newWeapon, this.transform);
            changedWeapon.name = changedWeapon.GetComponent<Weapon>().weaponName;
            playerWeapon = changedWeapon;

            weapon.GetComponent<DropedItem>().OnDestroy();
        }
    }

    public void PlayerOnTheFloor()
    {
        currentJumpCount = 0;
    }
    
    private void PlayerAttack()
    {
        if (Input.GetButtonDown("NormalAttack"))
        {
            playerWeapon.GetComponent<Weapon>().NormalAttack();
        }
        else if (Input.GetButtonDown("ChargeAttack"))
        {
            playerWeapon.GetComponent<Weapon>().ChargeAttack();
        }
    }

    private IEnumerator FallingDown()
    {
        this.GetComponent<BoxCollider2D>().isTrigger = true;
        yield return new WaitForSeconds(0.5f);
        this.GetComponent<BoxCollider2D>().isTrigger = false;
        yield return null;
    }

    private void PlayerMovement() // 움직임 우선순위 정하기
    {
        if (Input.GetAxis("Vertical") < 0) // FallDown
        {
            if (Input.GetButtonDown("Jump"))
            {
                StartCoroutine(FallingDown());
            }
        }
        else
        {
            if (Input.GetButtonDown("Jump") && currentJumpCount < player.playerMaxJumpCount) // JumpCheck
            {
                this.GetComponent<BoxCollider2D>().isTrigger = true;
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, player.playerJump);
                currentJumpCount++;
            }
            if (this.GetComponent<Rigidbody2D>().velocity.y < 0)    //TriggerCheck
                this.GetComponent<BoxCollider2D>().isTrigger = false;
        }
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * player.playerSpeed;
        transform.Translate(x, 0, 0);

        
    }

    private void Start()
    {
        GameObject weapon = Instantiate(playerWeapon, this.transform);
        weapon.name = weapon.GetComponent<Weapon>().weaponName;
        playerWeapon = weapon;
    }

    private void Update()
    {
        PlayerMovement();
        PlayerAttack();
    }

}
