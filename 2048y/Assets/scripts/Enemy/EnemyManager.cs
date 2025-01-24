using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    private static EnemyManager instance;
    public static EnemyManager Instance
    {
        get
        {
            if (instance == null)
                return null;
            return instance;
        }
    }

    public GameObject Bullet;

    public GameObject[] SpawnLocationA;
    public GameObject[] SpawnLocationB;

    public GameObject[] Enemy;
    public GameObject Boss;

    public GameObject UI;

    public float SpawnSec;
    public float BossSpaw;

    public bool iscutA;
    public bool iscutB;
    public bool iscutC;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this; 
        }
    }

    private void Update()
    {
        if(iscutA && iscutB && iscutC)
        {
            Destroy(gameObject);
            iscutA = false;
            iscutB = false;
            iscutC = false;
        }
    }

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    bool isbool = true;

    IEnumerator Spawn()
    {
        Invoke("BossSpawn", BossSpaw);
        StartCoroutine(warning());
        while(isbool)
        {
            yield return new WaitForSeconds(SpawnSec);
            int enemy = Random.Range(0, 2);

            int location = Random.Range(0, 3);

            if(enemy == 0)
            {
                Instantiate(Enemy[enemy], SpawnLocationA[location].transform.position, Quaternion.Euler(new Vector3(0,0,180)));
            }
            else
            {
                Instantiate(Enemy[enemy], SpawnLocationB[location].transform.position, Quaternion.Euler(new Vector3(0, 0, 180)));
            }
        }
    }

    IEnumerator warning()
    {
        yield return new WaitForSeconds(BossSpaw - 3);
        for(int i = 0; i < 3; i++)
        {
            UI.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            UI.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }
    }


    private void BossSpawn()
    {
        isbool = false;
        Instantiate(Boss);
    }

    private void OnDestroy()
    {
        Destroy(instance);
        PlayerState.Instance.end();
    }
}
