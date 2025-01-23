using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyB : DefaultEnemy
{
    public float Speed;

    Vector2 vec;

    private void Start()
    {
        vec = FindObjectOfType<PlayerState>().transform.position;
    }

    private void Update()
    {
        transform.position = Vector2.Lerp(transform.position, vec, Speed * Time.deltaTime);
    }

    protected override void OnDestroy()
    {
        PlayerState.Instance.score += score;
    }
}
