using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerState : MonoBehaviour
{
    private static PlayerState instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public static PlayerState Instance
    {
        get
        {
            if( instance == null)
            {
                return null;
            }    
            return instance;
        }
    }
    public float DMG;
    public float HP;
    public float Gauge;
    private float maxGauge;

    public Image HPbar;
    public Image GaugeBar;

    private void Start()
    {
        maxGauge = Gauge;
    }

    private void Update()
    {
        HPbar.fillAmount = HP/3;
        switch (HP)
        {
            case 0:
                break;
            case 1:
                HPbar.color = Color.red;
                break;
            case 2:
                HPbar.color = new Color(127, 128, 0);
                break;
            case 3:
                HPbar.color = Color.green;
                break;
        }
        GaugeBar.fillAmount = Gauge/maxGauge;
        if (Gauge > maxGauge)
            Gauge = maxGauge;
        Gauge -= Time.deltaTime;
        if(Gauge <= 0 || HP <= 0)
        {
            Debug.Log("Game Over");
            Time.timeScale = 0;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            HP -= 1;
            Destroy(collision.gameObject);
        }
    }
}
