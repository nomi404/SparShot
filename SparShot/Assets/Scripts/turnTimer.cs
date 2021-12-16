using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class turnTimer : MonoBehaviour
{

    public Image blue;
    public Image red;
    public float timeRemaining;


    GameObject battleSystem;
    public battleSsystem bs;
    ControllerPlayers cp;

    GameObject battleSystemAi;
    public battleSystemAi bsAi;
    controllerballAi cpAi;
    public GameObject time;
    public AudioSource timeSound;
    int count;
    private void Awake()
    {
        count = GameObject.FindGameObjectsWithTag("helper").Length;

    }
    void Start()
    {
        timeRemaining = 15;
        if (count == 0)
        {
            battleSystem = GameObject.FindGameObjectWithTag("battleSystem");
            bs = battleSystem.GetComponent<battleSsystem>();
            cp = GetComponent<ControllerPlayers>();
        }
        else
        {
            battleSystemAi = GameObject.FindGameObjectWithTag("battleSystemAi");
            bsAi = battleSystemAi.GetComponent<battleSystemAi>();
            cpAi = GetComponent<controllerballAi>();
        }
        time = GameObject.FindGameObjectWithTag("timeSound");
        timeSound = time.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }

        if (gameObject.tag == "p1")
        {
            red.fillAmount = timeRemaining / 15;
            timeSound.Play();
        }
        
        if (gameObject.tag == "p2")
        {
            timeSound.Play();
            blue.fillAmount = timeRemaining / 15;
        }

        if (timeRemaining < 0)
        {
            timeSound.Stop();
            if (count == 0)
                changeTurn();
            else
                changeTurnAi();
            //youchangedhere
        }


    }


    public void changeTurn()
    {

        if (gameObject.tag == "p2")
        {
            bs.p2TurnCount--;
            Destroy(bs.p2turnsBlue[bs.p2TurnCount].gameObject);
            bs.blueTurnDestroy();
        }

        if (gameObject.tag == "p1")
        {
            bs.p1TurnCount--;
            Destroy(bs.p1turnsRed[bs.p1TurnCount].gameObject);
            bs.redTurnDestroy();
        }



        if (cp.belongsToPlayer1)
        {
            bs.p2Turn();
        }
        else if (!cp.belongsToPlayer1)
        {
            bs.p1Turn();
        }


        cp.turnChanged = false;




        if (bs.state == gameState.p1Turn)
        {
            bs.state = gameState.p2Turn;
            red.fillAmount = 0;
        }

        else
        {
            bs.state = gameState.p1Turn;
            blue.fillAmount = 100;
        }

    } 
    
    public void changeTurnAi()
    {

        if (gameObject.tag == "p2")
        {
            bsAi.p2TurnCount--;
            Destroy(bsAi.p2turnsBlue[bsAi.p2TurnCount].gameObject);
            bsAi.blueTurnDestroy();
        }

        if (gameObject.tag == "p1")
        {
            bsAi.p1TurnCount--;
            Destroy(bsAi.p1turnsRed[bsAi.p1TurnCount].gameObject);
            bsAi.redTurnDestroy();
        }



        if (cpAi.belongsToPlayer1)
        {
            bsAi.p2Turn();
        }
        else if (!cpAi.belongsToPlayer1)
        {
            
        }


        cpAi.turnChanged = false;




        if (bsAi.state == gameState.p1Turn)
        {
            bsAi.state = gameState.p2Turn;
            red.fillAmount = 0;
        }

        else
        {
            bsAi.state = gameState.p1Turn;
            blue.fillAmount = 100;
        }
    }


    private void OnDisable()
    {
        timeRemaining = 15;
        


    }
}
