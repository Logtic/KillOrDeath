using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {
    public PlayerController playerController;
    public Slider playerHpBar;
    public Image playerWeaponImage;

    public void SetInit(PlayerController player)
    {
        playerController = player;
        ChangePlayerHpBar();
    }

    public void ChangePlayerHpBar()
    {
        playerHpBar.maxValue = playerController.player.playerMaxHp;
        playerHpBar.value = playerController.player.playerCurrentHp;
    }
    
}
