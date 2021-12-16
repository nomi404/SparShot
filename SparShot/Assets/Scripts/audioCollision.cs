using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioCollision : MonoBehaviour
{
    public AudioClip[] sound;
    public AudioSource play;
    Rigidbody2D rb;
  
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (rb.velocity.magnitude > 0&&collision.gameObject.tag=="table")
        //{
        //    if (count == 0)
        //    {
        //        play.PlayOneShot(sound[0]);
        //        count++;
        //    }else if (count == 1)
        //    {
        //        play.PlayOneShot(sound[count]);
        //        count++;
        //    } else if (count == 2)
        //    {
        //        play.PlayOneShot(sound[count]);
        //        count++;
        //    }

        //    else if (count == 3)
        //    {
        //        play.PlayOneShot(sound[count]);
        //        count++;
        //    }

        //}
        //else if(rb.velocity.magnitude==0)
        //{
        //    count = 0;
        //}

        //if (collision.gameObject.tag != "table")
        //{
        //    foreach (ContactPoint2D contact in collision.contacts)
        //    {
        //        play.PlayOneShot(sound[1]);
        //    }
        //}

        if (collision.relativeVelocity.magnitude > 4&&collision.gameObject.tag=="table")
        {
            play.PlayOneShot(sound[0]);
        }

       else if (collision.relativeVelocity.magnitude > 3 && collision.gameObject.tag == "table")
        {
            play.PlayOneShot(sound[1]);
        }
        else if (collision.relativeVelocity.magnitude > 2 && collision.gameObject.tag == "table")
        {
            play.PlayOneShot(sound[2]);
        }
        else if (collision.relativeVelocity.magnitude > 0 && collision.gameObject.tag == "table")
        {
            play.PlayOneShot(sound[3]);
        } 
        
        
       


        foreach (ContactPoint2D contact in collision.contacts)
        {
            if(collision.gameObject.tag=="p1"|| collision.gameObject.tag == "p2")
            {
                if (collision.relativeVelocity.magnitude > 3)
                {
                    play.PlayOneShot(sound[4]);
                }

                else if (collision.relativeVelocity.magnitude > 2)
                {
                    play.PlayOneShot(sound[5]);
                } 
                
                else if (collision.relativeVelocity.magnitude > 0)
                {
                    play.PlayOneShot(sound[6]);
                }
            }
        }

    }
}
