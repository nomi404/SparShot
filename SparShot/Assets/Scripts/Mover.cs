using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    Vector2 pos;
    public float speed = 3f;

    [SerializeField] float positionXgreater;
    [SerializeField] float positionXsmaller;
  

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       

        if (pos.x >= positionXgreater)
        {
            rb.velocity = new Vector2(-speed, 0);
        }

      else  if (pos.x <= positionXsmaller)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        pos = transform.position;

    }
}
