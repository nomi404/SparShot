using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayers : MonoBehaviour
{
    Vector2 startPos, endPos, direction;
    Rigidbody2D myRigidbody2D;
    public float Power = 10f;
    public float maxDrag = 1f;
    Trajectory tr;

    //Ignore below this
    public GameObject battleSystem;
    public battleSsystem bs;
    public bool belongsToPlayer1;
    public bool turnOverp1 = false;

    public bool turnChanged = false;

    Vector2 cpos;
    RaycastHit2D hit;


    GameObject soundStretch;
     AudioSource sound;

   public GameObject soundDeny;
     AudioSource deny; 
    
    
    public GameObject soundLet;
     AudioSource mouseUp;
  

    private void Awake()
    {
        battleSystem = GameObject.FindGameObjectWithTag("battleSystem");
        soundStretch= GameObject.FindGameObjectWithTag("sound");
        soundDeny = GameObject.FindGameObjectWithTag("soundDeny");
        soundLet= GameObject.FindGameObjectWithTag("mouseUp");
    }



    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        tr = GetComponent<Trajectory>();
        bs = battleSystem.GetComponent<battleSsystem>();
        sound = soundStretch.GetComponent<AudioSource>();
        deny = soundDeny.GetComponent<AudioSource>();
        mouseUp = soundLet.GetComponent<AudioSource>();

    }

    //Ignore till here
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
             cpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);


            

            if (hit.collider != null)
            {
               



                if (startPos.y > 0 && belongsToPlayer1)
                    tr.renderLine(gameObject.transform.position, cpos);



                else if (startPos.y < 0 && !belongsToPlayer1)
                    tr.renderLine(gameObject.transform.position, cpos);
            }
        }






    }






    void OnMouseDown()




    {



        if (!enabled) return;


        
        
        if (bs.state == gameState.Start) return;
        gameObject.GetComponent<TurnHandler>().enabled=true;

        gameObject.GetComponent<LineRenderer>().enabled = true;
       
        if (Input.GetMouseButtonDown(0))
        {


            startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            






        }

        if (startPos.y > 0)
        {
            if(!belongsToPlayer1)
                deny.Play();

            //posRed.pos = startPos;
        }

        if (startPos.y < 0)
        {
            if (belongsToPlayer1)
                deny.Play();

           // posBlue.pos = startPos;
        }



        if (startPos.y > 0 && belongsToPlayer1)
        {
            hit = Physics2D.Raycast(startPos, Vector2.up, 0f);
            bs.p1TimerDisable();
            bs.redTurnDestroy();
            sound.Play();
        }

        else if(startPos.y<0&&!belongsToPlayer1)
        {
            hit = Physics2D.Raycast(startPos, Vector2.up, 0f);
            bs.blueTurnDestroy();
            bs.p2TimerDisable();
            sound.Play();
        }




    }
  
    void OnMouseUp()
    {
        if (!enabled) return;
        if (bs.state == gameState.Start) return;
     
        gameObject.GetComponent<LineRenderer>().enabled = false;
      

        //This is the System for changing turn in local multipayer

        if (startPos.y > 0 && belongsToPlayer1)
        {

            mouseUp.Play();
            if (transform.childCount > 0)
            {
                if (gameObject.GetComponentInChildren<drag>().poweredUp == true)
                {
                    Destroy(this.gameObject.transform.GetChild(0).gameObject);
                    Power = 10;
                }
            }

            turnChanged = true;
        
            if (Input.GetMouseButtonUp(0))
            {
                endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                direction = startPos - endPos;


                myRigidbody2D.isKinematic = false;
                Vector2 force = startPos - endPos;
                Vector2 clampedForce = Vector2.ClampMagnitude(force, maxDrag) * Power;
                myRigidbody2D.AddForce(clampedForce, ForceMode2D.Impulse);

                bs.p1TurnCount--;
                Destroy(bs.p1turnsRed[bs.p1TurnCount].gameObject);
              
                tr.endLine();
                cpos = new Vector2(0, 0);
            }

        }


        //This is the System for changing turn in local multipayer

        else if (startPos.y < 0 && belongsToPlayer1 == false)
        {

            mouseUp.Play();
            if (transform.childCount > 0)
            {
                if (gameObject.GetComponentInChildren<drag>().poweredUp == true)
                {
                    Destroy(this.gameObject.transform.GetChild(0).gameObject);
                    Power = 10;
                }
            }

            turnChanged = true;
          
            if (Input.GetMouseButtonUp(0))
            {
                endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                direction = startPos - endPos;




                myRigidbody2D.isKinematic = false;
                Vector2 force = startPos - endPos;
                Vector2 clampedForce = Vector2.ClampMagnitude(force, maxDrag) * Power;
                myRigidbody2D.AddForce(clampedForce, ForceMode2D.Impulse);
                bs.p2TurnCount--;
                Destroy(bs.p2turnsBlue[bs.p2TurnCount].gameObject);
                tr.endLine();
                cpos = new Vector2(0, 0);
            }

        }










    }
}
