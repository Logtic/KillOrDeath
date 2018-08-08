using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour {
    public static void AttackPlayerToEnemy(Player player, Enemy enemy) {
        
        /*플레이어가 적한테 공격한다
         적이 받는 피해는 ( 플레이어의 공격력(playerAtk) + 플레이어의 무기(playerWeapon)의 공격력(weaponAtk) ) / ( 적의 방어력(enemyDef) )이다. 
         
         */
    }
    public static void AttackEnemyToPlayer(Player player, Enemy enemy) {
        
        /*적이 플레이어한테 공격한다.
         플레이어가 받는 피해는 ( 적의 공격력(enemyAtk) ) - ( 플레이어의 방어력(playerDef) ) / 2 이다.

         */
    }

    //각각 받은 피해가 음수가 되면 안되도록 조건도 맞춰줄 것!!
    //특히 적이 플레이어에게 공격하는 경우, 피해의 최솟값이 0이도록 맞춰주자.
    //만약 적의 공격력 2, 플레이어 방어력 6이면, 플레이어가 받는 피해는 2 - 6/2 = -1.. << 맞았는데 회복이 된다?? 변태는 아니니까 데미지 최솟값은 0이 되도록하자.
}
