using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class rankings
{
    public string name;
    public float score;
    public float time;

    public rankings(string name, float score, float time)
    {
        this.name = name;
        this.score = score;
        this.time = time;
    }
}

public class RankingManager : MonoBehaviour
{
    private static RankingManager instance;

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static RankingManager Instance
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

    public float score;
    public float time;
    private float resultTime;
    public List<rankings> rankings;

    public void ResetALL()
    {
        resultTime += time;
    }

    private void Update()
    {
        time += Time.deltaTime;
    }

    public void addscore(string name)
    {
        rankings newScore = new rankings(name, score, resultTime);
        score = 0;
        resultTime = 0;
        rankings.Add(newScore);
        rankings = rankings.OrderByDescending(s => s.score).ThenBy(s => s.time).Take(10).ToList();

    }

    public void ranking(GameObject[] Rankings)
    {
        for (int i = 0; i < Rankings.Length; i++)
        {
            if (rankings[i] == null)
            {
                return;
            }
            Rankings[i].transform.GetChild(0).GetComponent<Text>().text = rankings[i].score.ToString();
            Rankings[i].transform.GetChild(1).GetComponent<Text>().text = rankings[i].name.ToString();
            Rankings[i].transform.GetChild(2).GetComponent<Text>().text = $"{(int)rankings[i].time / 60}:{(int)rankings[i].time % 60}:" + (rankings[i].time - (int)rankings[i].time).ToString("F2");
        }
    }
}
