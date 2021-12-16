using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] bool isVSmode;
    [SerializeField] bool isAimode;
    [SerializeField] bool isSpeedScore;
    [SerializeField] bool isHoleGoal;


    [SerializeField] battleSystemAi bsAi;
    [SerializeField] battleSsystem bs;
    // Start is called before the first frame update

    // Update is called once per frame


    public void reload()
    {
        reset();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        reset();
        SceneManager.LoadScene("main menu");
    }

    void reset()
    {
        if (isVSmode)
        {
            battleSsystem.roundCount = 3; 
            battleSsystem.roundp2 = 0; 
            battleSsystem.roundp1 = 0;
        }
        else if(isAimode)
        {
            battleSystemAi.roundCount = 3;
            battleSystemAi.roundp1 = 0;
            battleSystemAi.roundp2 = 0;
        }



    }
}
