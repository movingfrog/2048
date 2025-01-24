using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealKit : MonoBehaviour
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
            PlayerState.Instance.Gauge += 20;
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
