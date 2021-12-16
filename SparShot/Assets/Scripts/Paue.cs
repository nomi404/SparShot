using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Paue : MonoBehaviour
{
    [SerializeField] battleSystemAi bsAi;
    [SerializeField] battleSsystem bs;
    private void OnEnable()
    {
        Time.timeScale = 0;
    }

    public void quit()
    {
        
        battleSystemAi.roundCount = 3;
        battleSsystem.roundCount = 3;
        battleSsystem.roundp1 = 0;
        battleSsystem.roundp2 = 0;
        battleSystemAi.roundCount = 3;
        battleSystemAi.roundp1 = 0;
        battleSystemAi.roundp2 = 0;
        SceneManager.LoadScene("main menu");
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
    }
}
