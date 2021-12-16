using System.Collections;

using UnityEngine;
using UnityEngine.Advertisements;

public class ads : MonoBehaviour, IUnityAdsListener
{
    public string gameId = "4295027";
   
  
   
    public bool testMode = true;
   
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        // Initialize the Ads service:
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, testMode);
    }






    public void ShowInterstitialAd()
    {

        if (Advertisement.IsReady())
        {
            Advertisement.Show("Interstitial_Android");
        }
        else
        {
            Debug.Log("Ads not ready");
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
        
    }

    public void OnUnityAdsDidError(string message)
    {
      
    }

    public void OnUnityAdsDidStart(string placementId)
    {

    }

    
    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
       
    }
}
