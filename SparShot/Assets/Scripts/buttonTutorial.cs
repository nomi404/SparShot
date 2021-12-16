using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonTutorial : MonoBehaviour
{
    [SerializeField] Button btsn;
   
    [SerializeField] firstCheck fs;
    [SerializeField] GameObject modesTut;
    [SerializeField] GameObject modes;

    
    [SerializeField] bool showTutorial;
    // Start is called before the first frame update
    private void Awake()
    {
     

        if (showTutorial)
            fs = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<firstCheck>();
    }
    void Start()
    {
        btsn = GetComponent<Button>();



        if (showTutorial)
        {
            if (fs.check())
                btsn.onClick.AddListener(mo);


            else
                btsn.onClick.AddListener(modesT);
        }
               



    }

    void modesT()
    {
        modesTut.SetActive(true);
    }
    void mo()
    {
        modes.SetActive(true);
    }

}
