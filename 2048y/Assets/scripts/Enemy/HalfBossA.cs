using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfBossA : DefaultEnemy
{

    private void Start()
    {
        Invoke("Fire", 3.5f);
    }

    private void Fire()
    {
        for (int index = 0;index < 5; index++)
        {
            GameObject bullet = Instantiate(EnemyManager.Instance.Bullet);
            bullet.transform.position = transform.position;

            Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
            Vector2 dirVec = PlayerState.Instance.transform.position - transform.position;
            Vector2 ranVec = new Vector2(Random.Range(-0.5f, 0.5f), Random.Range(0f, 2f));
            dirVec += ranVec;
            rigid.AddForce(dirVec.normalized * 6, ForceMode2D.Impulse);
        }

        Invoke("Fire", 3.5f);
    }
}
