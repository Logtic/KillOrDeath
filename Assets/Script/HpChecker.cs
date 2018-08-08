using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpChecker : MonoBehaviour {
    public Slider playerHpBar;
    public Slider enemyHpBar;

    public Player player;
    public Enemy enemy;

    private void SetInit()
    {
        playerHpBar.maxValue = player.playerMaxHp;
        playerHpBar.value = player.playerCurrentHp;
        enemyHpBar.maxValue = enemy.enemyMaxHp;
        enemyHpBar.value = enemy.enemyCurrentHp;
    }
    public void ValueChange()
    {
        enemyHpBar.value = enemy.enemyCurrentHp;
        playerHpBar.value = player.playerCurrentHp;
    }
    private void Update()
    {
        ValueChange();
    }
    private void Start()
    {
        SetInit();
    }
}
