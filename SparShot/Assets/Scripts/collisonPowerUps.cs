using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisonPowerUps : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "p1"|| collision.gameObject.tag == "p2")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity /= 1.5f;
        }
    }


   
}
