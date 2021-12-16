using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class score : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI scoreText;
    public int scoreBall = 0;
    int highScore = 0;

    private void Awake()
    {
        Time.timeScale = 1;
    }
    private void Start()
    {
        scoreBall = 0;
        highScore = PlayerPrefs.GetInt("highscore", highScore);

    }

    private void Update()
    {
        scoreText.text = "" + scoreBall;
    }

    public void changeScore()
    {
        if (scoreBall > highScore)
        {
            PlayerPrefs.SetInt("highscore", scoreBall);
        }
    }
}
