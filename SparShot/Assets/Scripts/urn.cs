using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class urn : MonoBehaviour
{
    GameObject[] go;
    GameObject[] go2;
    Rigidbody2D [] rigidbody2DRed;
    Rigidbody2D [] rigidbody2DBlue;
    // Start is called before the first frame update
    void Awake()
    {
        go = GameObject.FindGameObjectsWithTag("p1");   
        go2 = GameObject.FindGameObjectsWithTag("p2");

        rigidbody2DRed = new Rigidbody2D[go.Length];
        rigidbody2DBlue = new Rigidbody2D[go2.Length];
    }


    private void Start()
    {
        for (int i = 0; i < go.Length; i++)
        {
            rigidbody2DRed[i] = go[i].GetComponent<Rigidbody2D>();
            
        }
        
        
        for (int i = 0; i < go2.Length; i++)
        {
            rigidbody2DBlue[i] = go2[i].GetComponent<Rigidbody2D>();
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
