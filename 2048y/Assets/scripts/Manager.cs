using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public GameObject gameManual;
    public GameObject gameRank;

    public GameObject[] Rankings;



    public void Manual()
    {
        if(!gameManual.activeSelf)
        {
            gameManual.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            gameManual.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void Rank()
    {
        if(!gameRank.activeSelf)
        {
            gameRank.SetActive(true);
            RankingManager.Instance.ranking(Rankings);
            Time.timeScale = 0;
        }
        else
        {
            gameRank.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void GameStart()
    {
        SceneManager.LoadScene("gameScene");
    }
}
