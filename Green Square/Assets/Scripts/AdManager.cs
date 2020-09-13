using GoogleMobileAds.Api;
using UnityEngine;

public class AdManager : MonoBehaviour
{

    //private string APP_ID = "ca-app-pub-6093257465124252~5106272004";

    private RewardBasedVideoAd RewardVideoAd;

    void Start()
    {
        RequestVideoAd();

        // this is when u publis your app
        //MobileAds.Initialize(APP_ID);
    }

    void RequestVideoAd()
    {

        //For Real App
        /*
        string video_ID = "ca-app-pub-6093257465124252/5026380959";
        RewardVideoAd = RewardBasedVideoAd.Instance;
        AdRequest adRequest = new AdRequest.Builder().Build();
        RewardVideoAd.LoadAd(adRequest, video_ID);
        */

        //For Testing
        string video_ID = "ca-app-pub-3940256099942544/5224354917";
        RewardVideoAd = RewardBasedVideoAd.Instance;
        AdRequest adRequest = new AdRequest.Builder().AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();
        RewardVideoAd.LoadAd(adRequest, video_ID);

    }

    public void DisplayAd()
    {
        if (RewardVideoAd.IsLoaded())
            RewardVideoAd.Show();
    }


}

