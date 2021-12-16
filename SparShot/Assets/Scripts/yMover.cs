using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yMover : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    Vector2 pos;
    public float speed = 1f;

    [SerializeField] float positionYgreater;
    [SerializeField] float positionYsmaller;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {


        if (pos.y >= positionYgreater)
        {
            rb.velocity = new Vector2(0, -speed);
        }

        else if (pos.y <= positionYsmaller)
        {
            rb.velocity = new Vector2(0, speed);
        }
        pos = transform.position;

    }
}
