using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType { Weapon, Potion, Gold }
public class DropedItem : MonoBehaviour {

    public ItemType itemType;
    public string itemName;
    public Sprite itemSprite;
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (itemType == ItemType.Weapon)
                collision.gameObject.GetComponent<PlayerController>().ChangeWeapon(this.gameObject);
        }
    }
    
    public void OnDestroy()
    {
        Destroy(this.gameObject);
    }
}
