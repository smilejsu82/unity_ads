using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public partial class AdsManager : MonoBehaviour
{
    [SerializeField] Button loadBannerButton;
    [SerializeField] Button showBannerButton;
    [SerializeField] Button hideBannerButton;

    [SerializeField] BannerPosition _bannerPosition = BannerPosition.BOTTOM_CENTER;

    public void InitBanner() {

        showBannerButton.interactable = false;
        hideBannerButton.interactable = false;

        Advertisement.Banner.SetPosition(_bannerPosition);

        loadBannerButton.onClick.AddListener(LoadBanner);
        loadBannerButton.interactable = true;
    }

    public void LoadBanner()
    {
        BannerLoadOptions options = new BannerLoadOptions
        {
            loadCallback = OnBannerLoaded,
            errorCallback = OnBannerError
        };

        Advertisement.Banner.Load("Banner_Android", options);
    }

    void OnBannerLoaded()
    {
        Debug.Log("Banner loaded");

        showBannerButton.onClick.AddListener(ShowBannerAd);
        hideBannerButton.onClick.AddListener(HideBannerAd);

        showBannerButton.interactable = true;
        hideBannerButton.interactable = true;
    }

    void OnBannerError(string message)
    {
        Debug.Log($"Banner Error: {message}");
    }

    void ShowBannerAd()
    {
        BannerOptions options = new BannerOptions
        {
            clickCallback = OnBannerClicked,
            hideCallback = OnBannerHidden,
            showCallback = OnBannerShown
        };

        Advertisement.Banner.Show("Banner_Android", options);
    }

    void HideBannerAd()
    {
        Advertisement.Banner.Hide();
    }

    void OnBannerClicked() { }
    void OnBannerShown() { }
    void OnBannerHidden() { }

    public void ReleaseBanner() {
        loadBannerButton.onClick.RemoveAllListeners();
        showBannerButton.onClick.RemoveAllListeners();
        hideBannerButton.onClick.RemoveAllListeners();
    }

}
