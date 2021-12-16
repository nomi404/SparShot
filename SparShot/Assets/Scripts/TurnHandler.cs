using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TurnHandler : MonoBehaviour
{
    GameObject battleSystem;
    GameObject battleSystemAi;

    Rigidbody2D rb;
    public battleSsystem bs;
    public battleSystemAi bsAi;
    ControllerPlayers cp;
    controllerballAi cpAi;
    public TextMeshProUGUI turnRed;
    public TextMeshProUGUI turnBlue;
    
    int count;




    // Start is called before the first frame update
    private void Awake()
    {
        count = GameObject.FindGameObjectsWithTag("helper").Length;
    }
    void Start()
    {
         
        if (count == 0)
        {
            battleSystem = GameObject.FindGameObjectWithTag("battleSystem");
            bs = battleSystem.GetComponent<battleSsystem>();
            cp = GetComponent<ControllerPlayers>();
        }
        else
        {
            battleSystemAi= GameObject.FindGameObjectWithTag("battleSystemAi");
            bsAi= battleSystemAi.GetComponent<battleSystemAi>();
            cpAi = GetComponent<controllerballAi>();
        }
        rb = GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update()
    {


        if (count == 0)
        {
            checkStop();

            //if (bs.state == gameState.p1Turn)
            //{
            //    if (bs.CountRed() == false)
            //    {

            //        bs.p1TurnCount--;
            //        changeTurn();
            //    }
            //}



            //else if (bs.state == gameState.p2Turn)
            //{
            //    if (bs.CountBlue() == false)
            //    {
            //        bs.p2TurnCount--;
            //        changeTurn();
            //    }
            //}

        }

        else
        {
            checkStopAi();
        }
        //Debug.Log("Time: " + timer);
      


        //if (rb.velocity.magnitude == 0)
        //{
        //    timer += Time.fixedDeltaTime;
        //}
        //else if (rb.velocity.magnitude > 0)
        //    timer = 0;


        //if (timer > 10)
        //{
        //    changeTurn();
        //    timer = 0;
        //}








    }



    public void checkStop()
    {

        if (rb.velocity.magnitude < 0.20 && rb.velocity.magnitude > 0)
        {
            rb.velocity = new Vector2(0, 0);
            bs.ScriptsDisable();
        }


        if (rb.velocity.magnitude == 0)
            bs.ScriptsEnable();


        if (rb.velocity.magnitude == 0 && cp.turnChanged)
        {



            changeTurn();








        }




       
    }
    
    public void checkStopAi()
    {

        if (rb.velocity.magnitude < 0.20 && rb.velocity.magnitude > 0)
        {
            rb.velocity = new Vector2(0, 0);
            bsAi.ScriptsDisable();
        }


        if (rb.velocity.magnitude == 0)
            bsAi.ScriptsEnable();


        if (rb.velocity.magnitude == 0 && cpAi.turnChanged)
        {



            changeTurnAi();








        }




       
    }


    public void changeTurn()
    {
      
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
            bs.state = gameState.p2Turn;

        else
            bs.state = gameState.p1Turn;

    }  
    
    public void changeTurnAi()
    {
      
        if (cpAi.belongsToPlayer1)
        {
            bsAi.p2Turn();
        }
        else if (!cpAi.belongsToPlayer1)
        {
            bsAi.p1Turn();
        }


        cpAi.turnChanged = false;
        bsAi.redTurnDestroy();



        if (bsAi.state == gameState.p1Turn)
            bsAi.state = gameState.p2Turn;

        else
            bsAi.state = gameState.p1Turn;

    }


}
