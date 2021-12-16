using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotater : MonoBehaviour
{
    public float Speed = 30f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, Speed * Time.deltaTime);
    }
}
