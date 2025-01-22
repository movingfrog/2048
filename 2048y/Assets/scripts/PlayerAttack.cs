using System.Collections;
using System.Linq.Expressions;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject bullet;
    public float bulletSpeed;

    float time = 0;
    public float currentTime;

    private void FixedUpdate()
    {
        if(time >= currentTime)
        {
            if(Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.L))
            {
                time = 0;
                GameObject clone = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y + 0.75f), Quaternion.identity);

                Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();
                rb.AddForce(Vector2.up * bulletSpeed, ForceMode2D.Impulse);
            }
        }
        else
        {
            time += Time.deltaTime;
        }
    }

}
