using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelonAttackEffect : PlayerAttackEffect {

    public Sprite attack1;
    public Sprite attack2;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            BattleController.AttackPlayerToEnemy(this.transform.parent.GetComponent<PlayerController>().player, collision.gameObject.transform.parent.GetComponent<Enemy>());
            

        }
    }
    public IEnumerator Attacking(bool direct)
    {
        if (direct)
            this.transform.localPosition = new Vector3(16, 0.1f, 0);
        else
            this.transform.localPosition = new Vector3(-16, 0.1f, 0);
        this.GetComponent<BoxCollider2D>().enabled = false;
        this.GetComponent<SpriteRenderer>().sprite = attack1;
        for(int i = 0; i<3; i++)
        {
            this.GetComponent<SpriteRenderer>().color = new Color(this.GetComponent<SpriteRenderer>().color.r, this.GetComponent<SpriteRenderer>().color.g,
                this.GetComponent<SpriteRenderer>().color.b, this.GetComponent<SpriteRenderer>().color.a - (float)(0.3*i));
            yield return new WaitForSeconds(0.5f);
        }
        this.GetComponent<SpriteRenderer>().color = new Color(this.GetComponent<SpriteRenderer>().color.r, this.GetComponent<SpriteRenderer>().color.g,
                this.GetComponent<SpriteRenderer>().color.b, 1);
        this.GetComponent<SpriteRenderer>().sprite = attack2;
        this.GetComponent<BoxCollider2D>().enabled = true;
        yield return new WaitForSeconds(1.0f);
        this.transform.parent.GetComponent<MelonController>().AgainSetting();
        this.gameObject.SetActive(false);
        yield return null;
    }
    
}
