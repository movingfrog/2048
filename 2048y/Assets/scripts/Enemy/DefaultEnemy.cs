using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultEnemy : MonoBehaviour
{
    public float HP;

    public GameObject[] Item;

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            HP -= PlayerState.Instance.DMG;
            takeDamage();
            if (HP <= 0)
            {
                if (Random.Range(1, 6) == 3)
                {
                    drop();
                }
                Destroy(gameObject);
            }
        }
    }

    protected void takeDamage()
    {
        SpriteRenderer sp = gameObject.GetComponent<SpriteRenderer>();
        if(sp.color.a == 255)
        {
            sp.color = new Color(255, 255, 255, 100);
            Invoke("takeDamage", 0.5f);
        }
        else
        {
            sp.color = new Color(255,255,255,255);
            return;
        }
    }

    protected void drop()
    {
        int r = Random.Range(0, 4);
        Instantiate(Item[r], new Vector3(transform.position.x, transform.position.y - 0.5f,0), Quaternion.identity);
    }
}
