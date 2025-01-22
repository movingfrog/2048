using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Awake()
    {
        if(instance == null)
        {
            instance = this; 
        }
    }

    private void OnDestroy()
    {
        Destroy(instance);
    }
}
