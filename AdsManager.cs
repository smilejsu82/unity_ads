using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public partial class AdsManager : IUnityAdsInitializationListener, IUnityAdsShowListener
{
    public static AdsManager instance;

    [SerializeField] string androidGameId;
    [SerializeField] string iOsGameId;
    [SerializeField] bool testMode = true;
    [SerializeField] bool enablePerPlacementMode = true;
    private string gameId;

    void Awake()
    {
        AdsManager.instance = this;
        DontDestroyOnLoad(this.gameObject);
        InitializeAds();
    }

    public void InitializeAds()
    {
        gameId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? iOsGameId
            : androidGameId;
        Advertisement.Initialize(gameId, testMode, enablePerPlacementMode, this);
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }

    void OnDestory() {
        ReleaseBanner();
    }

    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        Debug.LogFormat ("OnUnityAdsAdLoaded: {0}", adUnitId);

        if (adUnitId == "Interstitial_Android")
        {
            this.btnShowInterstitial.interactable = true;
        }
        else if (adUnitId == "Rewarded_Android") {
            this.btnShowReward.interactable = true;
        }
    }

    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit: {adUnitId} - {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowStart(string adUnitId) { }
    public void OnUnityAdsShowClick(string adUnitId) { }
}
