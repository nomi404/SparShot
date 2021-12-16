using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holeController : MonoBehaviour
{
    Vector2 startPos, endPos, direction;
    Rigidbody2D myRigidbody2D;
    public float Power = 10f;
    public float maxDrag = 1f;
    Trajectory tr;

    //Ignore below this
   
    public bool belongsToPlayer1;
 

    Vector2 cpos;
    RaycastHit2D hit;


    //GameObject soundStretch;
    //AudioSource sound;

    //public GameObject soundDeny;
    //AudioSource deny;


    //public GameObject soundLet;
    //AudioSource mouseUp;


    private void Awake()
    {
      
        //soundStretch = GameObject.FindGameObjectWithTag("sound");
        //soundDeny = GameObject.FindGameObjectWithTag("soundDeny");
        //soundLet = GameObject.FindGameObjectWithTag("mouseUp");
    }



    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        tr = GetComponent<Trajectory>();
      
        //sound = soundStretch.GetComponent<AudioSource>();
        //deny = soundDeny.GetComponent<AudioSource>();
        //mouseUp = soundLet.GetComponent<AudioSource>();

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




        


        gameObject.GetComponent<LineRenderer>().enabled = true;

        if (Input.GetMouseButtonDown(0))
        {


            startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);







        }

        if (startPos.y > 0)
        {
           // if (!belongsToPlayer1) ;
               // deny.Play();

            //posRed.pos = startPos;
        }

        if (startPos.y < 0)
        {
            //if (belongsToPlayer1)
               // deny.Play();

            // posBlue.pos = startPos;
        }



        if (startPos.y > 0 && belongsToPlayer1)
        {
            hit = Physics2D.Raycast(startPos, Vector2.up, 0f);
          
           // sound.Play();
        }

        else if (startPos.y < 0 && !belongsToPlayer1)
        {
            hit = Physics2D.Raycast(startPos, Vector2.up, 0f);
           
           // sound.Play();
        }




    }

    void OnMouseUp()
    {
        if (!enabled) return;
       

        gameObject.GetComponent<LineRenderer>().enabled = false;


        //This is the System for changing turn in local multipayer

        if (startPos.y > 0 && belongsToPlayer1)
        {

           // mouseUp.Play();
            if (transform.childCount > 0)
            {
                if (gameObject.GetComponentInChildren<drag>().poweredUp == true)
                {
                    Destroy(this.gameObject.transform.GetChild(0).gameObject);
                    Power = 10;
                }
            }

         

            if (Input.GetMouseButtonUp(0))
            {
                endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                direction = startPos - endPos;


                myRigidbody2D.isKinematic = false;
                Vector2 force = startPos - endPos;
                Vector2 clampedForce = Vector2.ClampMagnitude(force, maxDrag) * Power;
                myRigidbody2D.AddForce(clampedForce, ForceMode2D.Impulse);

               

                tr.endLine();
                cpos = new Vector2(0, 0);
            }

        }


        //This is the System for changing turn in local multipayer

        else if (startPos.y < 0 && belongsToPlayer1 == false)
        {

           // mouseUp.Play();
            if (transform.childCount > 0)
            {
                if (gameObject.GetComponentInChildren<drag>().poweredUp == true)
                {
                    Destroy(this.gameObject.transform.GetChild(0).gameObject);
                    Power = 10;
                }
            }

            

            if (Input.GetMouseButtonUp(0))
            {
                endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                direction = startPos - endPos;




                myRigidbody2D.isKinematic = false;
                Vector2 force = startPos - endPos;
                Vector2 clampedForce = Vector2.ClampMagnitude(force, maxDrag) * Power;
                myRigidbody2D.AddForce(clampedForce, ForceMode2D.Impulse);
               
                tr.endLine();
                cpos = new Vector2(0, 0);
            }

        }










    }
}
