using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MilkShake;
public class playerCollision : MonoBehaviour
{

    public GameObject hit;
   
   
    GameObject power;


    public Shaker MyShaker;
   
    public ShakePreset ShakePresetLow;
    public ShakePreset ShakePresetMid;
    public ShakePreset ShakePresetHigh;

     void shakeItLow()
    {

        MyShaker.Shake(ShakePresetLow);
    }  
    
    void shakeItMid()
    {
      
        MyShaker.Shake(ShakePresetMid);
    }
     public void shakeItHigh()
    {
        
        MyShaker.Shake(ShakePresetHigh);
    }


    private void Start()
    {
        power = GameObject.FindGameObjectWithTag("electric");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {




        if (collision.gameObject.tag == "p2"|| collision.gameObject.tag == "p1")
        {
            
            foreach (ContactPoint2D missileHit in collision.contacts)
            {
                Vector2 hitPoint = missileHit.point;
                Instantiate(hit, new Vector3(hitPoint.x, hitPoint.y, 0), Quaternion.identity);
                

            }
        }



        if (collision.relativeVelocity.magnitude > 5)
        {
            shakeItHigh();
        }
        else if (collision.relativeVelocity.magnitude > 2&&collision.relativeVelocity.magnitude<5)
        {
            shakeItMid();
        } 
        
        else if (collision.relativeVelocity.magnitude <=2&&collision.relativeVelocity.magnitude>0)
        {
            shakeItLow();
        }




    }



    

}
