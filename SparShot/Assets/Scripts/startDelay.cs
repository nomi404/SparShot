using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startDelay : MonoBehaviour
{
    [SerializeField] GameObject timer;
   
    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            timer.SetActive(true);
            
            Destroy(gameObject);
        }
    }
}
