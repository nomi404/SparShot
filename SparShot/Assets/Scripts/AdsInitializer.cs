using UnityEngine;
using UnityEngine.Advertisements;

public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] string _androidGameId;
    [SerializeField] string _iOsGameId;
    [SerializeField] bool _testMode = true;
    [SerializeField] bool _enablePerPlacementMode = true;
    [SerializeField] GameObject loadAd;
    private string _gameId;

    void Awake()
    {

        GameObject[] objs = GameObject.FindGameObjectsWithTag("adObjLoader");        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }        DontDestroyOnLoad(this.gameObject);
        InitializeAds();
        loadAd = GameObject.FindGameObjectWithTag("loadAd");
    }

    public void InitializeAds()
    {
        _gameId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? _iOsGameId
            : _androidGameId;
        Advertisement.Initialize(_gameId, _testMode, _enablePerPlacementMode, this);
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");

        loadAd.GetComponent<InterstitialAdExample>().LoadAd();
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }
}