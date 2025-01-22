using System.Collections;
using UnityEngine;

public class EnemyA : DefaultEnemy
{
    public float bulletSpeed;

    public Vector2 vec = new Vector2(0,2.5f);

    private void Start()
    {
        StartCoroutine(Pattern());
    }

    IEnumerator Pattern()
    {
        for(float one = 0;one <1;one += Time.deltaTime)
        {
            transform.position = Vector2.Lerp(transform.position, vec, Time.deltaTime * 7);
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(0.05f);
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
        yield return null;
        for(float one = 0;one < 1;one += Time.deltaTime)
        {
            transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x, -7.5f), Time.deltaTime * 7);
            yield return new WaitForSeconds(0.02f);
        }
        Destroy(gameObject);
    }
}
