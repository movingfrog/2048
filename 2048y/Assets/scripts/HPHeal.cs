using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPHeal : MonoBehaviour
{
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
            PlayerState.Instance.HP = 3;
            Destroy(gameObject);
        }
        if (collision.CompareTag("wall"))
            Destroy(gameObject);
    }

    private void OnDestroy()
    {
        RankingManager.Instance.score += 500;
    }
}
