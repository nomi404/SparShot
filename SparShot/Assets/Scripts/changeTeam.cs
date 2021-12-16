using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeTeam : MonoBehaviour
{


    public Sprite blueBall;
    public Sprite redBall;


    SpriteRenderer sp;




   



   [SerializeField] TrailRenderer trail;

    int count;

    private void Awake()
    {
        count = GameObject.FindGameObjectsWithTag("helper").Length;
        
    }



    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
     
        trail =GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        

        if (gameObject.tag == "p1" && gameObject.transform.position.y < 0)
        {
            gameObject.tag = "p2";


            trail.material.SetColor("_TintColor", new Color(69f, 158f, 220f));
            

            //  gameObject.GetComponent<ControllerPlayers>().belongsToPlayer1 = false;

            //gameObject.GetComponent<player1Controller>().enabled = false;
            /// gameObject.GetComponent<player2Controller>().enabled = true;
            sp.sprite = blueBall;
            
        }


        if (gameObject.tag == "p2" && gameObject.transform.position.y > 0)
        {
            gameObject.tag = "p1";
            trail.material.SetColor("_TintColor", new Color(254f, 76f, 97f));
            
            // gameObject.GetComponent<ControllerPlayers>().belongsToPlayer1 = true;
            // gameObject.GetComponent<player1Controller>().enabled = true;
            //gameObject.GetComponent<player2Controller>().enabled = false;


            sp.sprite = redBall;
        }
    }


   
}
