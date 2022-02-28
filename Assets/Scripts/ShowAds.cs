using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class ShowAds : MonoBehaviour
 {
    /*
     
    void Start()
    {

        
    }

    public static void ShowAd()
    {
        //if(Advertisement.IsReady())
        //{
           // Advertisement.Show();
            
       // }
    }

    /// <summary>
    /// This is the rewarded video on the start screen. If the player watches the ad he gets 50 coins.
    /// </summary>
    public void ShowRewardedVideo()
    {
        ShowOptions options = new ShowOptions();
        options.resultCallback = HandleShowResult;

        Advertisement.Show("rewardedVideo", options);
    }

    static void HandleShowResult(ShowResult result)
    {
        if (result == ShowResult.Finished)
        {
            Debug.Log("Video completed - Offer a reward to the player");
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 50);
            // Reward your player here.

        }
        else if (result == ShowResult.Skipped)
        {
            Debug.Log("Video was skipped - Do NOT reward the player");

        }
        else if (result == ShowResult.Failed)
        {
            Debug.Log("Video failed to show");
        }
    }

    /// <summary>
    /// This is the rewarded video on the game over screen. If the player watches the ad he can continue from where he lost.
    /// </summary>
    
    public void ShowRewardedVideoContinue()
    {

        ShowOptions options = new ShowOptions();
        options.resultCallback = HandleShowResultContinue;

        Advertisement.Show("rewardedVideo", options);
    }

    public static double AdScoreBonus;
    public static int watchedAd;
    void HandleShowResultContinue(ShowResult result)
    {
       
        if (result == ShowResult.Finished)
        {
            Debug.Log("Video completed - Offer a reward to the player");
            SceneManager.LoadScene("GameScene");
            AdScoreBonus = PlayerPrefs.GetInt("CurrentScore");
            watchedAd = 1;
            // Reward your player here.

        }
        else if (result == ShowResult.Skipped)
        {
            Debug.Log("Video was skipped - Do NOT reward the player");

        }
        else if (result == ShowResult.Failed)
        {
            Debug.Log("Video failed to show");
        }
    }

    */
}
