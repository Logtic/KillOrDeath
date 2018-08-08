using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInGame : MonoBehaviour {
    public Player player;

    static UIInGame UIInstance;

    private void Start()
    {
        UIInstance = this;
    }

}
