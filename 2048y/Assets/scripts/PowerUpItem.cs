using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpItem : MonoBehaviour
{
    public static int count = 0;
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.velocity = new Vector2(0, -5);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(count == 3)
            {
                PlayerState.Instance.DMG = 500;
            }
            if(count < 3)
            {
                count++;
                collision.GetComponent<PlayerAttack>().currentTime -= 0.1f;
            }
            Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
        PlayerState.Instance.score += 500;
    }
}
