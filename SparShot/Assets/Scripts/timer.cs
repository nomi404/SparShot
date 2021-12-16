using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timer : MonoBehaviour
{
    [SerializeField]float time=0;
    TextMeshProUGUI timeShow;

    [SerializeField] GameObject ballSpawn;
    [SerializeField] GameObject holeSpawn;

    // Start is called before the first frame update
    void Start()
    {
        timeShow = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        ballSpawn.SetActive(true);
        holeSpawn.SetActive(true);
        time = 3;
      
    }

    // Update is called once per frame
    void Update()
    {
        
        if (time < 0)
        {
            
            gameObject.SetActive(false);
        }
        else
        {
            timeShow.text = "" + ((int)(time)+1);
           
        }

        time -= Time.deltaTime;
    }

    private void OnDisable()
    {
        
    }
}
