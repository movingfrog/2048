using UnityEngine;
using UnityEngine.UI;

public class LastBoss : DefaultEnemy
{
    public Image HPImage;
    public GameObject EnemyB;

    public int patternIndex = 0;
    public int curpatternIndex;
    public int[] maxPatternCount;

    private void Start()
    {
        Think();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            HP -= PlayerState.Instance.DMG;
            score += PlayerState.Instance.DMG;
            takeDamage(transform.GetChild(0).GetComponent<SpriteRenderer>());
            Debug.Log("fdklsj");
            if (HP <= 0)
            {
                if (Random.Range(1, 6) == 3)
                {
                    drop();
                }
                Debug.Log("dfklsj");
                Destroy(gameObject);
            }
        }
    }

    void commenFire()
    {
        Debug.Log("3");
        GameObject bullet = Instantiate(EnemyManager.Instance.Bullet);
        bullet.transform.position = transform.position;
        bullet.transform.rotation = Quaternion.identity;

        Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
        Vector2 dirVec = new Vector2(Mathf.Cos(Mathf.PI * 10 * curpatternIndex / maxPatternCount[patternIndex]), -1);
        rigid.AddForce(dirVec.normalized * 5, ForceMode2D.Impulse);
        curpatternIndex++;

        if (curpatternIndex < maxPatternCount[patternIndex])
            Invoke("commenFire", 0.15f);
        else
            Invoke("Think", 3);
    }

    private void Update()
    {
        HPImage.fillAmount = HP / 30000;
    }

    void Think()
    {
        patternIndex = patternIndex == 3 ? 0 : patternIndex + 1;
        curpatternIndex = 0;
        switch (patternIndex)
        {
            case 0:
                PatternA();
                break;
            case 1:
                Shotgun();
                break;
            case 2:
                spawn();
                break;
            case 3:
                commenFire();
                break;

        }
    }

    void PatternA()
    {
        Debug.Log("0");
        int roundA = 15;
        int roundB = 10;
        int round = curpatternIndex % 2 == 0 ? roundA : roundB;

        for (int i = 0; i < round; i++)
        {
            GameObject bullet = Instantiate(EnemyManager.Instance.Bullet);
            bullet.transform.position = transform.position;
            bullet.transform.rotation = Quaternion.identity;


            Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
            Vector2 dirVec = new Vector2(Mathf.Sin(Mathf.PI * 2 * i / round), Mathf.Sin(Mathf.PI * 2 * i / round));

            Vector3 rotVec = Vector3.forward * 360 * i / round + Vector3.forward * 90;
            bullet.transform.Rotate(rotVec);

            rigid.AddForce(dirVec.normalized * 2, ForceMode2D.Impulse);
        }
        curpatternIndex++;
        if (curpatternIndex >= maxPatternCount[patternIndex])
        {
            Invoke("Think", 3f);
        }
        else
        {
            Invoke("PatternA", 1f);
        }
    }

    void Shotgun()
    {
        Debug.Log("1");
        for (int index = 0; index < 5; index++)
        {
            GameObject bullet = Instantiate(EnemyManager.Instance.Bullet);
            bullet.transform.position = transform.position;

            Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
            Vector2 dirVec = PlayerState.Instance.transform.position - transform.position;
            Vector2 ranVec = new Vector2(Random.Range(-0.5f, 0.5f), Random.Range(0f, 2f));
            dirVec += ranVec;
            rigid.AddForce(dirVec.normalized * 6, ForceMode2D.Impulse);
        }

        curpatternIndex++;
        if (curpatternIndex < maxPatternCount[patternIndex])
        {
            Invoke("Shotgun", 0.55f);
        }
        else
            Invoke("Think", 3f);
    }

    void spawn()
    {
        Debug.Log("2");
        float ran = Random.Range(-10, 10);
        Instantiate(EnemyB, transform.position + new Vector3(ran, 6, 0), Quaternion.Euler(0, 0, 180));
        curpatternIndex++;

        if (curpatternIndex < maxPatternCount[patternIndex])
            Invoke("spawn", 2.5f);
        else
            Invoke("Think", 3);
    }

    protected override void OnDestroy()
    {
        PlayerState.Instance.end();
    }
}
