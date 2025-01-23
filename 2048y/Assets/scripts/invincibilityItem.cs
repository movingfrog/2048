using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invincibilityItem : MonoBehaviour
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
            PlayerState.Instance.hitsc(5f);
            Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
        PlayerState.Instance.score += 500;
    }
}
