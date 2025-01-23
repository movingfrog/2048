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
            if(instance == null)
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
    public float score = 0;

    public Image HPbar;
    public Image GaugeBar;
    public Text Score;

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
        if (Gauge > 100)
            Gauge = 100;
        GaugeBar.fillAmount = Gauge/maxGauge;
        if (Gauge > maxGauge)
            Gauge = maxGauge;
        Gauge -= Time.deltaTime;
        Score.text = score.ToString();
        if(Gauge <= 0 || HP <= 0)
        {
            Debug.Log("Game Over");
            Time.timeScale = 0;
            gameObject.transform.GetChild(0).transform.parent = GameObject.FindWithTag("MainCamera").transform;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            HP -= 1;
            hitsc(2.5f);
            Destroy(collision.gameObject);
        }
    }

    public void hitsc(float hita)
    {
        gameObject.layer = 7;
        StartCoroutine(hit());
        Invoke("ch", hita);
    }

    bool isbool = true;

    IEnumerator hit()
    {
        while (isbool)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            yield return new WaitForSeconds(0.3f);
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            yield return new WaitForSeconds(0.3f);
        }
    }

    void ch()
    {
        isbool = false;
        gameObject.layer = 6;
    }

}
