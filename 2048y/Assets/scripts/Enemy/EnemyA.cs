using System.Collections;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class EnemyA : DefaultEnemy
{
    public float bulletSpeed;

    private void Start()
    {
        StartCoroutine(Pattern());
    }

    IEnumerator Pattern()
    {
        Vector2 vec = new Vector2(transform.position.x, 2.5f);
        for (float one = 0;one <1;one += Time.deltaTime)
        {
            transform.position = Vector2.Lerp(transform.position, vec, Time.deltaTime * 7);
            yield return new WaitForSeconds(0.02f);
        }
        for(int i = 0; i < 3; i++)
        {
            GameObject bullet = Instantiate(EnemyManager.Instance.Bullet);
            bullet.transform.position = transform.position;

            Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
            Vector2 dirVec = PlayerState.Instance.transform.position - transform.position;
            Vector2 ranVec = new Vector2(Random.Range(-0.5f, 0.5f), Random.Range(0f, 2f));
            dirVec += ranVec;
            rigid.AddForce(dirVec.normalized * bulletSpeed, ForceMode2D.Impulse);
            yield return new WaitForSeconds(1);
        }
        for(float one = 0;one < 1;one += Time.deltaTime)
        {
            transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x, -7.5f), Time.deltaTime * 7);
            yield return new WaitForSeconds(0.02f);
        }
        Destroy(gameObject);
    }

    protected override void OnDestroy()
    {
        RankingManager.Instance.score += score;
        Debug.Log("dfsjklsfdjkl");
    }
}
