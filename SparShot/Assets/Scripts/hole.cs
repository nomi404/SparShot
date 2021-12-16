using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class hole : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI turnRed;
    [SerializeField] TextMeshProUGUI turnBlue;
    public battleSsystem bs;
    [SerializeField] AudioSource holeSound;
    [SerializeField] GameObject poof;
    [SerializeField] GameObject BlueWon;
    [SerializeField] GameObject RedWon;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "p1" && gameObject.tag == "holeRed")
        {
            collision.gameObject.GetComponent<TurnHandler>().changeTurn();
            holeSound.Play();
            collision.gameObject.GetComponent<playerCollision>().shakeItHigh();
            Destroy(collision.gameObject);
            Instantiate(poof, gameObject.transform.position, gameObject.transform.rotation);
            
           
        }

        


         if (collision.gameObject.tag == "p2" && gameObject.tag == "holeBlue")
        {
            collision.gameObject.GetComponent<TurnHandler>().changeTurn();
            holeSound.Play();
            collision.gameObject.GetComponent<playerCollision>().shakeItHigh();
            Destroy(collision.gameObject);
            Instantiate(poof, gameObject.transform.position,gameObject.transform.rotation);
            
        }


       

    }

    private void FixedUpdate()
    {
        if (bs.CountRed() == false)
        {
            redWon();
        }

        else if (bs.CountBlue() == false)
        {
            blueWon();
        }
    }


    void redWon()
    {




        RedWon.SetActive(true);

    } 
    
    void blueWon()
    {

        BlueWon.SetActive(true);




    }
}
