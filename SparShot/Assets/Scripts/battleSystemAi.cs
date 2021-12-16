using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;



public class battleSystemAi : MonoBehaviour
{
    //Waiting for game to start...
    public float timeStart;

    public gameState state;
    int randomTurn = 0;
    public int p1TurnCount = 5;
    public int p2TurnCount = 5;

    public bool blueSelected = false;
    public bool redSelected = false;


    int countRedsp1 = 0;
    int countBluep2 = 0;


    [SerializeField] GameObject redDefault;
    [SerializeField] GameObject redImage;
    [SerializeField] GameObject blueDefault;
    [SerializeField] GameObject blueImage;

    [SerializeField] AudioSource roundOver;



   public static int roundCount = 3;
    public static int roundp1 = 0;
    public static int roundp2 = 0;



    public TextMeshProUGUI waitMessage;
    public TextMeshProUGUI turnsLeftRed;
    public TextMeshProUGUI turnsLeftBlue;
    public TextMeshProUGUI roundsRed;
    public TextMeshProUGUI roundsBlue;


    public GameObject winner;
    public GameObject newRound;


    public GameObject redRing;
    public bool red = false;
    public GameObject blueRing;
    public bool blue = false;


    public GameObject roundWin;
    public GameObject roundWin2;



    public GameObject table1;
    public GameObject table2;
    public GameObject table3;


    public GameObject celebration;


    public GameObject[] p1turnsRed;
    public GameObject[] p2turnsBlue;


    public TextMeshProUGUI turnRed;
    public TextMeshProUGUI turnBlue;

    public GameObject lightRound1;
    public GameObject lightRound2;
    public GameObject lightRound3;

     [SerializeField] InterstitialAdExample ad;
    [SerializeField] AudioSource background;
    [SerializeField] AudioClip round1Music;
    [SerializeField] AudioClip round2Music;
    [SerializeField] AudioClip round3Music;
    public GameObject transition;


    [SerializeField] GameObject gameOverBlueWin;
    [SerializeField] GameObject gameOverRedWin;
    [SerializeField] GameObject gameOverDraw;

    private void Awake()
    {
        DontDestroyOnLoad(roundsBlue);
        DontDestroyOnLoad(roundsRed);
       // ad = GameObject.FindGameObjectWithTag("loadAd").GetComponent<InterstitialAdExample>();
    }

    // Start is called before the first frame update
    void Start()
    {


        
        state = gameState.Start;
       // ad.ShowAd();
        StartCoroutine(setupBattle());







    }



    IEnumerator setupBattle()
    {


        waitMessage.text = "Waiting for game to start...";
       
        yield return new WaitForSeconds(timeStart);
        
        waitMessage.gameObject.SetActive(false);

        transition.SetActive(true);

        if (!blueSelected)
        {
            blueDefault.SetActive(true);
            blueImage.SetActive(false);

        }

        if (!redSelected)
        {
            redDefault.SetActive(true);
            redImage.SetActive(false);
        }
        if (roundCount == 3)
        {
            table1.SetActive(true);
            lightRound1.SetActive(true);
            background.PlayOneShot(round1Music);
        }


        else if (roundCount == 2)
        {
            table2.SetActive(true);
            lightRound2.SetActive(true);
            background.PlayOneShot(round2Music);
        }

        else if (roundCount == 1)
        {
            table3.SetActive(true);
            lightRound3.SetActive(true);
            background.PlayOneShot(round3Music);
        }


        int count = GameObject.FindGameObjectsWithTag("helper").Length;

        if (count == 0)
        {
            randomTurn = Random.Range(1, 3);
            Debug.Log("Random Number is: " + randomTurn);
            if (randomTurn == 1)
            {

                p1Turn();
                red = true;
                state = gameState.p1Turn;



            }

            else if (randomTurn == 2)
            {
                p2Turn();
                blue = true;
                state = gameState.p2Turn;




            }

        }

        else
        {
            p2Turn();
            blue = true;
            state = gameState.p2Turn;
        }
       
    }

    private void Update()
    {


        if (p1TurnCount == 0 && p2TurnCount == 0)
        {
            ScriptsDisable();
            state = gameState.stop;
            p1TurnCount = -1;
            p2TurnCount = -1;


        }




      






        if (state == gameState.p1Turn && red)
        {
            redTurn();
            red = false;


        }



        if (state == gameState.p2Turn && blue)
        {
            blueTurn();
            blue = false;

        }
        if (state == gameState.stop)
        {
            roundOver.Play();
            winner.SetActive(true);
            StartCoroutine(checkWinner());

        }


        if (state == gameState.p1Win)
        {
            turnRed.text = "YOU\nWON";
            turnBlue.text = "YOU\nLOST";
        }

        else if (state == gameState.p2Win)
        {
            turnRed.text = "YOU\nLOST";
            turnBlue.text = "YOU\nWON";
        }

        else if (state == gameState.draw)
        {
            turnRed.text = "ROUND\nDRAW";
            turnBlue.text = "ROUND\nDRAW";
        }


        if (state == gameState.draw || state == gameState.p1Win || state == gameState.p2Win)
        {
            winner.SetActive(false);


            StartCoroutine(nextRound());




        }


    }








    public void p1Turn()
    {

        GameObject[] ball = GameObject.FindGameObjectsWithTag("p1");
        int countRed = GameObject.FindGameObjectsWithTag("p1").Length;
        int randomNumber = Random.Range(0, countRed);
        ball[randomNumber].GetComponent<AIShot>().enabled = true;
        p1TimerEnable();
        p2TimerDisable();
        p1Enable();//enables the player 1 controller
        p2Disable();//disables player 2 controller






    }
    public void p2Turn()
    {
        p2TimerEnable();
        p1TimerDisable();
        p2Enable();//enables the player 2 controller
        p1Disable();//disables player 1 controller




    }


    public void p2Disable()
    {
        GameObject[] objs;
        objs = GameObject.FindGameObjectsWithTag("p2");
        foreach (GameObject p2 in objs)
        {
            //  p2.GetComponent<player2Controller>().enabled = false;
            p2.GetComponent<controllerballAi>().belongsToPlayer1 = true;
        }

    }
    void p2Enable()
    {
        blue = true;
        GameObject[] objs;
        objs = GameObject.FindGameObjectsWithTag("p2");
        foreach (GameObject p2 in objs)
        {
            //  p2.GetComponent<player2Controller>().enabled = true;
            p2.GetComponent<controllerballAi>().belongsToPlayer1 = false;
        }
    }

    public void p1Disable()
    {
        GameObject[] objs;
        objs = GameObject.FindGameObjectsWithTag("p1");
        foreach (GameObject p1 in objs)
        {
            // p1.GetComponent<player1Controller>().enabled = false;
            p1.GetComponent<controllerballAi>().belongsToPlayer1 = false;
        }
    }

    void p1Enable()
    {
        red = true;
        GameObject[] objs;
        objs = GameObject.FindGameObjectsWithTag("p1");
        foreach (GameObject p1 in objs)
        {
            // p1.GetComponent<player1Controller>().enabled = true;
            p1.GetComponent<controllerballAi>().belongsToPlayer1 = true;
        }
    }

    public void ScriptsDisable()
    {

        GameObject[] objs;
        objs = GameObject.FindGameObjectsWithTag("p1");
        foreach (GameObject p1 in objs)
        {
            // p1.GetComponent<player1Controller>().enabled = true;
            p1.GetComponent<controllerballAi>().enabled = false;
        }


        //for player2



        objs = GameObject.FindGameObjectsWithTag("p2");
        foreach (GameObject p2 in objs)
        {
            // p1.GetComponent<player1Controller>().enabled = true;
            p2.GetComponent<controllerballAi>().enabled = false;
        }
    }


    public void ScriptsEnable()
    {

        GameObject[] objs;
        objs = GameObject.FindGameObjectsWithTag("p1");
        foreach (GameObject p1 in objs)
        {
            // p1.GetComponent<player1Controller>().enabled = true;
            
        }


        //for player2



        objs = GameObject.FindGameObjectsWithTag("p2");
        foreach (GameObject p2 in objs)
        {
            // p1.GetComponent<player1Controller>().enabled = true;
            p2.GetComponent<controllerballAi>().enabled = true;
        }
    }


    IEnumerator checkWinner()
    {

        yield return new WaitForSeconds(5);

        countRedsp1 = GameObject.FindGameObjectsWithTag("p1").Length;
        countBluep2 = GameObject.FindGameObjectsWithTag("p2").Length;




        if (countRedsp1 < countBluep2)
        {
            state = gameState.p1Win;
        }



        else if (countRedsp1 > countBluep2)
        {
            state = gameState.p2Win;
        }


        else if (countRedsp1 == countBluep2)
        {
            state = gameState.draw;
        }





    }



    IEnumerator nextRound()
    {

        //if (state == gameState.p1Win)
        //    roundp1++;

        //else if (state == gameState.p2Win)
        //    roundp2++;

        if (roundp1 < 2 || roundp2 < 2)
            newRound.SetActive(true);
        yield return new WaitForSeconds(5f);
        if (roundp1 < 2 || roundp2 < 2)
            newRound.SetActive(false);

        roundCount--;


        if (state == gameState.p1Win)
        {
            roundp1++;
            if (roundCount > 0)
                if (roundp1 == 1)
                    Instantiate(roundWin, roundWin.gameObject.transform.position = new Vector2(-0.78f, 6.57f), transform.rotation);



        }


        else if (state == gameState.p2Win)
        {
            roundp2++;
            if (roundCount > 0)
                if (roundp2 == 1)
                    Instantiate(roundWin, roundWin.gameObject.transform.position = new Vector2(-0.78f, -6.57f), transform.rotation);
        }

        if (roundp2 == 2 || roundp1 == 2)
        {
            roundCount = 0;
        }


        if (roundCount > 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        else
        {

           

             //   Instantiate(celebration, celebration.gameObject.transform.position = new Vector2(2, 5.4f), transform.rotation);

              
               
               // Instantiate(celebration, celebration.gameObject.transform.position = new Vector2(1, 1.4f), transform.rotation);
                
               // Instantiate(celebration, celebration.gameObject.transform.position = new Vector2(-2, 2.4f), transform.rotation);
               
                
                StartCoroutine(menu());

            


        }
    }


    IEnumerator waitSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        //Instantiate here
    }

    IEnumerator menu()
    {
        ad.ShowAd();
        yield return new WaitForSeconds(0f);
        if (roundp1 == roundp2)
        {
            gameOverDraw.SetActive(true);
        }

        else if (roundp1 > roundp2)
        {
            gameOverRedWin.SetActive(true);
        }

        else if (roundp1 < roundp2)
        {
            gameOverBlueWin.SetActive(true);
        }
        roundCount = 3;
        roundp1 = 0;
        roundp2 = 0;
        this.gameObject.SetActive(false);

    }
    void redTurn()
    {

        GameObject[] objs;
        objs = GameObject.FindGameObjectsWithTag("p1");

        if (p1TurnCount > 0)
        {
            foreach (GameObject p1 in objs)
            {

                // p1.GetComponent<player1Controller>().enabled = true;
               
                GameObject red = Instantiate(redRing, p1.gameObject.transform.position, p1.gameObject.transform.rotation);
                red.transform.parent = p1.gameObject.transform;
            }

            
        }


    }


    void blueTurn()
    {

        GameObject[] objs;
        objs = GameObject.FindGameObjectsWithTag("p2");

        if (p2TurnCount > 0)
        {
            foreach (GameObject p2 in objs)
            {

                // p1.GetComponent<player1Controller>().enabled = true;

                GameObject blue = Instantiate(blueRing, p2.gameObject.transform.position, p2.gameObject.transform.rotation);
                blue.transform.parent = p2.gameObject.transform;
            }
        }


    }


    public void redTurnDestroy()
    {

        GameObject[] objs;
        objs = GameObject.FindGameObjectsWithTag("redTurn");
        foreach (GameObject p1 in objs)
        {

            // p1.GetComponent<player1Controller>().enabled = true;
            p1.gameObject.SetActive(false);
            Destroy(p1.gameObject);
        }
    }

    public void blueTurnDestroy()
    {

        GameObject[] objs;
        objs = GameObject.FindGameObjectsWithTag("blueTurn");
        foreach (GameObject p1 in objs)
        {

            // p1.GetComponent<player1Controller>().enabled = true;
            Destroy(p1.gameObject);
        }
    }


    void p1TimerEnable()
    {
        GameObject[] objs;
        objs = GameObject.FindGameObjectsWithTag("p1");
        foreach (GameObject p1 in objs)
        {
            // p1.GetComponent<player1Controller>().enabled = true;
            p1.GetComponent<turnTimer>().enabled = true;
        }
    }

    public void p1TimerDisable()
    {
        GameObject[] objs;
        objs = GameObject.FindGameObjectsWithTag("p1");
        foreach (GameObject p1 in objs)
        {
            // p1.GetComponent<player1Controller>().enabled = true;
            p1.GetComponent<turnTimer>().enabled = false;
        }
    }


    void p2TimerEnable()
    {
        GameObject[] objs;
        objs = GameObject.FindGameObjectsWithTag("p2");
        foreach (GameObject p2 in objs)
        {
            // p1.GetComponent<player1Controller>().enabled = true;
            p2.GetComponent<turnTimer>().enabled = true;
        }
    }

    public void p2TimerDisable()
    {
        GameObject[] objs;
        objs = GameObject.FindGameObjectsWithTag("p2");
        foreach (GameObject p2 in objs)
        {
            // p1.GetComponent<player1Controller>().enabled = true;
            p2.GetComponent<turnTimer>().enabled = false;
        }
    }


}
