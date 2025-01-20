using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject bullet;

    float time = 0;
    public float currentTime;

    private void FixedUpdate()
    {
        if(time >= currentTime)
        {
            if(Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.L))
            {
                time = 0;
                Instantiate(bullet, new Vector3(transform.position.x, transform.position.y + 0.75f), Quaternion.identity);
            }
        }
        else
        {
            time += Time.deltaTime;
        }
    }
}
