using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeRed : MonoBehaviour
{
    public float timeRemaining = 10;


    GameObject battleSystem;
    public battleSsystem bs;
    ControllerPlayers cp;




    void Start()
    {
        battleSystem = GameObject.FindGameObjectWithTag("battleSystem");
        bs = battleSystem.GetComponent<battleSsystem>();
        cp = GetComponent<ControllerPlayers>();
    }

    private void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }

        if (timeRemaining < 0)
        {
            changeTurn();
            timeRemaining = 10;
        }


    }


    public void changeTurn()
    {
        bs.p1TurnCount--;
        Destroy(bs.p1turnsRed[bs.p1TurnCount].gameObject);
        bs.redTurnDestroy();

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

    private void OnDisable()
    {
        timeRemaining = 10;
    }
}
