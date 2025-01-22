using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfBossB : DefaultEnemy
{
    int currentpatern = 0;

    private void Start()
    {
        fire();
    }

    void fire()
    {
        int roundA = 20;
        int roundB = 10;
        int round = currentpatern % 2 == 0? roundA : roundB;

        for(int i = 0; i < round; i++)
        {
            GameObject bullet = Instantiate(EnemyManager.Instance.Bullet);
            bullet.transform.position = transform.position;
            bullet.transform.rotation = Quaternion.identity;


            Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
            Vector2 dirVec = new Vector2(Mathf.Cos(Mathf.PI * 2 * i / round), Mathf.Sin(Mathf.PI * 2 * i / round));
            rigid.AddForce(dirVec.normalized * 2, ForceMode2D.Impulse);

            Vector3 rotVec = Vector3.forward * 360  * i / round + Vector3.forward * 90;
            bullet.transform.Rotate(rotVec);
        }
        currentpatern++;
        if (currentpatern % 3 == 0)
        {
            Invoke("fire", 3);
        }
        else
            fire();
    }
}
