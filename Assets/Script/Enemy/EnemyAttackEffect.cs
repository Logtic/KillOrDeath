using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackEffect : MonoBehaviour {

    public bool attack = false;
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && attack == false)
        {
            BattleController.AttackEnemyToPlayer(collision.gameObject.GetComponent<PlayerController>().player, this.transform.parent.GetComponent<Enemy>());
            attack = true;
            UIInGame.UIInstance.playerUI.ChangePlayerHpBar();
            
        }
    }

    public void DisableEffect()
    {
        this.transform.parent.GetComponent<Enemy>().enemyTrigger.endAttack = true;
        this.gameObject.SetActive(false);
    }
}
