using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour {
    public Slider enemyHpBar;
    public Enemy enemy;

    public void ChangeEnemyHpBar()
    {
        enemyHpBar.value = enemy.enemyCurrentHp;
        if (enemy.enemyCurrentHp<=0)
        {
            Destroy(this.gameObject);
        }
    }

    public void SetInit(Enemy newEnemy)
    {
        enemy = newEnemy;
        enemyHpBar.gameObject.SetActive(true);
        enemyHpBar.maxValue = enemy.enemyMaxHp;
        enemyHpBar.value = enemy.enemyCurrentHp;
    }

    private void Update()
    {
        this.transform.position = Camera.main.WorldToScreenPoint(enemy.enemyTrigger.transform.position) + new Vector3(0, enemy.enemyTrigger.enemyHeight, 0);
        ChangeEnemyHpBar();
        
    }
}
