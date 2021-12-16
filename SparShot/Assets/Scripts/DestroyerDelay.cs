using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerDelay : MonoBehaviour
{

    [SerializeField] float delay;
    [SerializeField]GameObject smoke;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, delay);
    }

    private void OnDestroy()
    {
        if(gameObject.tag=="ball")
        Instantiate(smoke, transform.position, transform.rotation);
    }
    
    public void ps()
    {
        
        Instantiate(smoke, transform.position, transform.rotation);
    }
}
