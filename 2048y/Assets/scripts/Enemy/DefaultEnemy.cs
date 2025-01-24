using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class DefaultEnemy : MonoBehaviour
{
    public float HP;
    protected float score;

    public GameObject[] Item;

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            HP -= PlayerState.Instance.DMG;
            score += PlayerState.Instance.DMG;
            Take();
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

    protected virtual void Take()
    {

    }

    protected void takeDamage(SpriteRenderer sp)
    {
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
        int r = Random.Range(0, 5);
        Instantiate(Item[r], transform.position, Quaternion.identity);
    }

    protected abstract void OnDestroy();
}
