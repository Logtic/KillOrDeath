using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text;

public class tempFloor_2 : MonoBehaviour
{
    public void SetRandomTrans()
    {
        float t = Random.Range(-10.0f, 10.0f);
        this.transform.position = new Vector3(t, -50.0f, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision) //트리거를 만났을때
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Transform>().position = new Vector3(0, 10, 0);
            SetRandomTrans();
        }
    }
}
