using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PlayerType { Tomato, Grape, Lemon, Melon}
public class Player : MonoBehaviour {
    public PlayerType playerType;

    public int playerAtk;
    public int playerMaxHp;
    public int playerCurrentHp;

    public int playerSpeed;
    public int playerJump;
    public int playerMaxJumpCount;
    public string playerCurrentSceneName;
   
}
