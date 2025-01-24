using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class stagechange : MonoBehaviour
{
    public static int stagenum;
    public GameObject input;

    private void OnEnable()
    {
        transform.GetChild(0).gameObject.GetComponent<Text>().text = "STAGE " + stagenum;
        transform.GetChild(1).GetChild(0).GetComponent<Text>().text = $"{(int)RankingManager.Instance.time / 60}:{(int)RankingManager.Instance.time % 60}:" + (RankingManager.Instance.time - (int)RankingManager.Instance.time).ToString("F2");
        transform.GetChild(2).GetChild(0).GetComponent<Text>().text = RankingManager.Instance.score.ToString();
        if (PlayerState.Instance == null)
        {
            input.SetActive(true);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && PlayerState.Instance != null)
        {
            stagenum = stagenum >= 2 ? 0 : stagenum;
            Time.timeScale = 1;
            SceneManager.LoadScene(stagenum);
        }
    }
}
