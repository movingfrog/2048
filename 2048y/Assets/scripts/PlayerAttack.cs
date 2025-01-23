using System.Collections;
using System.Linq.Expressions;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject bullet;
    public GameObject Bullet;
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

                switch(PowerUpItem.count)
                {
                    case 0:
                        GameObject clone = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y + 0.75f), Quaternion.identity);

                        Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();
                        rb.AddForce(Vector2.up * bulletSpeed, ForceMode2D.Impulse);
                        break;
                    case 1:

                        GameObject cloneR = Instantiate(bullet, new Vector3(transform.position.x + 0.1f, transform.position.y + 0.75f), Quaternion.identity);
                        GameObject cloneL = Instantiate(bullet, new Vector3(transform.position.x - 0.1f, transform.position.y + 0.75f), Quaternion.identity);
                        cloneR.GetComponent<SpriteRenderer>().color = Color.red;
                        cloneL.GetComponent<SpriteRenderer>().color = Color.red;
                        Rigidbody2D rigidR = cloneR.GetComponent<Rigidbody2D>();
                        Rigidbody2D rigidL = cloneL.GetComponent<Rigidbody2D>();
                        rigidR.AddForce(Vector2.up * bulletSpeed, ForceMode2D.Impulse);
                        rigidL.AddForce(Vector2.up * bulletSpeed, ForceMode2D.Impulse);
                        break;
                        case 2:
                        GameObject cloneRR = Instantiate(bullet, new Vector3(transform.position.x + 0.2f, transform.position.y + 0.75f), Quaternion.identity);
                        GameObject cloneCC = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y + 0.75f), Quaternion.identity);
                        GameObject cloneLL = Instantiate(bullet, new Vector3(transform.position.x - 0.2f, transform.position.y + 0.75f), Quaternion.identity);
                        cloneRR.GetComponent<SpriteRenderer>().color = Color.red;
                        cloneCC.GetComponent<SpriteRenderer>().color = new Color(255, 255, 0);
                        cloneLL.GetComponent<SpriteRenderer>().color = Color.red;
                        Rigidbody2D rigidRR = cloneRR.GetComponent<Rigidbody2D>();
                        Rigidbody2D rigidCC = cloneCC.GetComponent<Rigidbody2D>();
                        Rigidbody2D rigidLL = cloneLL.GetComponent<Rigidbody2D>();
                        rigidRR.AddForce(Vector2.up * bulletSpeed, ForceMode2D.Impulse);
                        rigidCC.AddForce(Vector2.up * bulletSpeed, ForceMode2D.Impulse);
                        rigidLL.AddForce(Vector2.up * bulletSpeed, ForceMode2D.Impulse);
                        break;
                    case 3:

                        GameObject Rclone = Instantiate(Bullet, new Vector3(transform.position.x, transform.position.y + 0.75f), Quaternion.identity);

                        Rigidbody2D rigid = Rclone.GetComponent<Rigidbody2D>();
                        rigid.AddForce(Vector2.up * bulletSpeed, ForceMode2D.Impulse);
                        break;
                }
            }
        }
        else
        {
            time += Time.deltaTime;
        }
    }

}
