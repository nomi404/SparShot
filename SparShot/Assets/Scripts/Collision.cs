using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MilkShake;

namespace VolumetricLines
{

    public class Collision : MonoBehaviour
    {
        

       
        public VolumetricLineBehavior[] vl;
        
        private void Start()
        {
           
           
           
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {

            if (gameObject.tag == "table"&& collision.gameObject.tag=="p2")
            {
               
                foreach (VolumetricLineBehavior li in vl)
                {

                    li.LineColor = new Color32(65, 160, 223, 255);
                    
                }
            }

            if (gameObject.tag == "table" && collision.gameObject.tag == "p1")
            {
                
                foreach (VolumetricLineBehavior li in vl)
                {

                    li.LineColor = new Color32(254, 76, 97, 255);

                }
            }



        }



    }
}