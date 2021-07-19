using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class AdsMain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AdsManager.instance.InitBanner();
        AdsManager.instance.InitInterstitialAds();
        AdsManager.instance.InitRewardedAds();
    }   
}
