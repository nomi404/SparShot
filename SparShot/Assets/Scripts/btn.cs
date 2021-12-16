using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btn : MonoBehaviour
{

    [SerializeField] Button btsn;
    [SerializeField] InterstitialAdExample ad;
   

    [SerializeField] bool showAdvert;
   
    // Start is called before the first frame update
    private void Awake()
    {
        if(showAdvert)
             ad = GameObject.FindGameObjectWithTag("loadAd").GetComponent<InterstitialAdExample>();

       
    }
    void Start()
    {
       btsn=GetComponent<Button>();
        if(showAdvert)
            btsn.onClick.AddListener(showAd);

     
            


    }

    void showAd()
    {
        ad.ShowAd();
    }
   
}
