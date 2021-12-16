using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class relocate : MonoBehaviour
{
    Vector2 pos;
    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 0 && gameObject.tag == "p2"&&rb.velocity.magnitude==0)
        {
            pos.x= Random.Range(-2.29f,2.29f);
            pos.y = Random.Range(-1.2f, -5.4f);
            transform.position = pos;
        }

        else if (transform.position.y < 0 && gameObject.tag == "p1" && rb.velocity.magnitude == 0)
        {
            pos.x = Random.Range(-2.29f, 2.29f);
            pos.y = Random.Range(0.3f, 4.96f);
            transform.position = pos;
        }
    }

}
