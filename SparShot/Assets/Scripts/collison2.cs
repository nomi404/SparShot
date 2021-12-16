using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VolumetricLines
{

    public class collison2 : MonoBehaviour
    {



        public VolumetricLineBehavior[] vl;
       
        private void Start()
        {
            


        }

        private void OnCollisionEnter2D(Collision2D collision)
        {

            if (gameObject.tag == "table" && collision.gameObject.tag == "p2")
            {
               
                foreach (VolumetricLineBehavior li in vl)
                {

                    li.LineColor = new Color32(54, 116, 98, 255);

                }
            }

            if (gameObject.tag == "table" && collision.gameObject.tag == "p1")
            {
               
                foreach (VolumetricLineBehavior li in vl)
                {

                    li.LineColor = new Color32(116, 101, 85, 255);

                }
            }



        }



    }
}
