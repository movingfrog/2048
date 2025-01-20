using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float V = Input.GetAxisRaw("Vertical");
        float H = Input.GetAxisRaw("Horizontal");
        if (V != 0 || H != 0)
        {
            rb.velocity = new Vector2(H, V) * speed;
        }
        else
            rb.velocity = Vector2.zero;
    }
}
