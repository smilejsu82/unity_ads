using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public partial class AdsManager : MonoBehaviour
{

    public Button btnLoadInterstitial;
    public Button btnShowInterstitial;

    public void InitInterstitialAds() {
        this.btnShowInterstitial.interactable = false;
        this.btnLoadInterstitial.onClick.AddListener(() => {
            AdsManager.instance.LoadInterstitialAds();
        });
        this.btnShowInterstitial.onClick.AddListener(() => {
            AdsManager.instance.ShowInterstitialAds();
        });
    }

    public void LoadInterstitialAds()
    {
        Debug.Log("Loading Ad: " + "Interstitial_Android");
        Advertisement.Load("Interstitial_Android", this);
    }

    public void ShowInterstitialAds()
    {
        Debug.Log("Showing Ad: " + "Interstitial_Android");
        Advertisement.Show("Interstitial_Android", this);
        this.btnShowInterstitial.interactable = false;
    }

    
}
