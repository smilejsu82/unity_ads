using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public partial class AdsManager : MonoBehaviour, IUnityAdsLoadListener
{
    public Button btnLoadReward;
    public Button btnShowReward;

    public void InitRewardedAds()
    {
        this.btnShowReward.interactable = false;
        this.btnLoadReward.onClick.AddListener(() => {
            AdsManager.instance.LoadRewardAd();
        });
        this.btnShowReward.onClick.AddListener(() => {
            AdsManager.instance.ShowRewardedAd();
        });
    }

    // Load content to the Ad Unit:
    public void LoadRewardAd()
    {
        // IMPORTANT! Only load content AFTER initialization (in this example, initialization is handled in a different script).
        Debug.Log("Loading Ad: " + "Rewarded_Android");
        Advertisement.Load("Rewarded_Android", this);
    }


    // Implement a method to execute when the user clicks the button.
    public void ShowRewardedAd()
    {
        // Then show the ad:
        Advertisement.Show("Rewarded_Android", this);
        this.btnShowReward.interactable = false;
    }

    // Implement the Show Listener's OnUnityAdsShowComplete callback method to determine if the user gets a reward:
    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        if (adUnitId.Equals("Rewarded_Android") && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            Debug.Log("Unity Ads Rewarded Ad Completed");
            // Grant a reward.

            // Load another ad:
            Advertisement.Load("Rewarded_Android", this);
        }
    }

}
