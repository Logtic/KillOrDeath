using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour {
    public static void AttackPlayerToEnemy(Player player, Enemy enemy) {

        enemy.enemyCurrentHp -= player.playerAtk;
        enemy.DeadCheck();
        
    }
    public static void AttackEnemyToPlayer(Player player, Enemy enemy) {
        player.playerCurrentHp -= enemy.enemyAtk;
        player.transform.parent.GetComponent<PlayerController>().PlayerCheckDead();
    }
    
}
