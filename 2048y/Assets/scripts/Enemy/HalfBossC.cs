using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfBossC : DefaultEnemy
{
    private void Start()
    {
        Fire();
    }

    protected override void Take()
    {
        takeDamage(gameObject.GetComponent<SpriteRenderer>());
    }
    void Fire()
    {
        GameObject bullet = Instantiate(EnemyManager.Instance.Bullet);
        bullet.transform.position = transform.position;

        Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
        Vector2 dirVec = PlayerState.Instance.transform.position - transform.position;
        Vector2 ranVec = new Vector2(Random.Range(-0.5f, 0.5f), Random.Range(0f, 2f));
        dirVec += ranVec;
        rigid.AddForce(dirVec.normalized * 6, ForceMode2D.Impulse);
        Debug.Log("dfslkj");
        Invoke("Fire", 0.4f);
    }
    protected override void OnDestroy()
    {
        RankingManager.Instance.score += score;
        EnemyManager.Instance.iscutC = true;
        drop();
    }

}
