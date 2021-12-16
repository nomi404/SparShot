using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VolumetricLines
{

    public class collision3 : MonoBehaviour
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

                    li.LineColor = new Color32(145, 131, 46, 255);

                }
            }

            if (gameObject.tag == "table" && collision.gameObject.tag == "p1")
            {
                
                foreach (VolumetricLineBehavior li in vl)
                {

                    li.LineColor = new Color32(27, 146, 121, 255);

                }
            }



        }



    }
}