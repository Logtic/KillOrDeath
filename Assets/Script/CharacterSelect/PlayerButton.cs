using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerButton : MonoBehaviour {
    public PlayerType playerType;
    public bool isSelected;

    public void SelectPlayer()
    {
        SelectUI.selectUI.SelectPlayer(playerType);
    }

}
