using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LemonAttackEffect : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
                BattleController.AttackPlayerToEnemy(this.transform.parent.GetComponent<PlayerController>().player, collision.gameObject.transform.parent.GetComponent<Enemy>());
                
           

        }
    }

    public void SetOffArrow()
    {
        this.gameObject.SetActive(false);
    }
}
