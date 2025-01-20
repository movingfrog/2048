using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerState : MonoBehaviour
{
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
                Destroy(gameObject);
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
            default:
                HP = 3;
                break;
        }
        GaugeBar.fillAmount = Gauge/maxGauge;
        if (Gauge > maxGauge)
            Gauge = maxGauge;
        Gauge -= Time.deltaTime;
    }
}
