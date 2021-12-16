using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballCheck : MonoBehaviour
{

    int count = 0;
    int count2 = 0;
    public GameObject Player1;
    public GameObject Player2;
    bool isMovePlayer1=false;
    bool isMovePlayer2=false;



    // Update is called once per frame
    void Update()
    {
        if (isMovePlayer1 && isMovePlayer2)
        {
            posCheck();
        }

        isStopped();


    }






    void posCheck()
    {
        if (Player1.transform.position.y > 0 && Player2.transform.position.y > 0)
        {
            count = 2;
        }
        else
        {
            count = 0;
        }
        if (Player1.transform.position.y < 0 && Player2.transform.position.y < 0)
        {
            count2 = 2;
        }
        else
        {
            count2 = 0;
        }




        if (count == 2)
        {
            Player1.transform.position = new Vector2(Player1.transform.position.x, -2f);
           
        }
        if (count2 == 2)
        {
            Player2.transform.position = new Vector2(Player1.transform.position.x, 2f);

        }


    }
    void isStopped()
    {

        if (Player1.GetComponent<Rigidbody2D>().velocity.magnitude < 0.01f)
        {

            isMovePlayer1 = true;
        }

        else
        {
            isMovePlayer1 = false;
        }

        if (Player2.GetComponent<Rigidbody2D>().velocity.magnitude < 0.01f)
        {
            isMovePlayer2 = true;
        }

        else
        {
            isMovePlayer2 = false;
        }
    }
           
}
