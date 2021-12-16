using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class showScore : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI score;
    [SerializeField]score sc;
    [SerializeField] PlayGames pg;
    int highScore;
    public bool changeTrue = false;
    private void OnEnable()
    {
        Time.timeScale = 0;
    }
    private void Awake()
    {
        pg = GameObject.FindGameObjectWithTag("playStore").GetComponent<PlayGames>();
        highScore = PlayerPrefs.GetInt("highscore", highScore);
    }

    


    private void Update()
    {
        if (changeTrue)
        {
            sc.changeScore();
            score.text = "YOUR SCORE: " + sc.scoreBall + "\nHIGH SCORE:" + highScore; ;
            pg.AddScoreToLeaderboard(sc.scoreBall);
            sc.gameObject.SetActive(false);

        }

    }
}
