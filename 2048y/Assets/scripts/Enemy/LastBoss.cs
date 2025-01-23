using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LastBoss : DefaultEnemy
{
    public Image HPImage;
    public GameObject EnemyB;

    int patternIndex = 0;
    int curpatternIndex;
    int[] maxPatternCount;

    private void Start()
    {
        Think();
    }

    void commenFire()
    {
        GameObject bullet = Instantiate(EnemyManager.Instance.Bullet);
        bullet.transform.position = transform.position;
        bullet.transform.rotation = Quaternion.identity;

        Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
        Vector2 dirVec = new Vector2(Mathf.Cos(Mathf.PI * 10 * curpatternIndex / maxPatternCount[patternIndex]), -1);
        curpatternIndex++;

        if (curpatternIndex < maxPatternCount[patternIndex])
            Invoke("commenFire", 0.75f);
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
        switch (curpatternIndex)
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
        int roundA = 15;
        int roundB = 10;
        int round = curpatternIndex % 2 == 0 ? roundA : roundB;

        for (int i = 0; i < round; i++)
        {
            GameObject bullet = Instantiate(EnemyManager.Instance.Bullet);
            bullet.transform.position = transform.position;
            bullet.transform.rotation = Quaternion.identity;


            Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
            Vector2 dirVec = new Vector2(Mathf.Cos(Mathf.PI * 2 * i / round), Mathf.Sin(Mathf.PI * 2 * i / round));

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
        for (int index = 0; index < 5; index++)
        {
            GameObject bullet = Instantiate(EnemyManager.Instance.Bullet);
            bullet.transform.position = transform.position;

            Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
            Vector2 dirVec = PlayerState.Instance.transform.position - transform.position;
            Vector2 ranVec = new Vector2(Random.Range(-0.5f, 0.5f), Random.Range(0f, 2f));
            dirVec += ranVec;
            rigid.AddForce(dirVec.normalized * 6, ForceMode2D.Impulse);
            curpatternIndex++;
        }

        if (curpatternIndex < maxPatternCount[patternIndex])
        {
            Invoke("Shotgun", 0.15f);
        }
        else
            Invoke("Think", 3f);
    }

    void spawn()
    { 
        for(int index = 0;index< 5;index++)
        {
            float ran = Random.Range(-10, 10);
            Instantiate(EnemyB, transform.position + new Vector3(ran, 6, 0), Quaternion.Euler(0, 0, 180));
        }
        Invoke("Think", 3);
    }

    protected override void OnDestroy()
    {

    }
}
