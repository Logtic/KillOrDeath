using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animating : MonoBehaviour {

    public List<Sprite> IdleState;
    public List<Sprite> AttackState;

    IEnumerator IdleMove()
    {
        foreach(Sprite s in IdleState)
        {
            this.GetComponent<SpriteRenderer>().sprite = s;
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void IdleMoveAnimation()
    {
        StartCoroutine(IdleMove());
    }
}
