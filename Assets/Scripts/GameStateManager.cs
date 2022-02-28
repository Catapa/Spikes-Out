using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.UI;


public class GameStateManager : MonoBehaviour {
   

    int exitCounter;
    public GameObject PausePanel;
    //public GameObject Antagonist;

    void Start()
    {

        if (PlayerPrefs.GetInt("Coins") == 0 && PlayerPrefs.GetInt("GivedCoins") == 0)
        {
            PlayerPrefs.SetInt("Coins", 0);
            PlayerPrefs.SetInt("GivedCoins", 1);

            //2X Multiplier
            PlayerPrefs.SetInt("Duration 2X Multiplier", 5);
            PlayerPrefs.SetInt("Level 2X Multiplier", 1);
            PlayerPrefs.SetInt("Cost 2X Multiplier", 250);

            //Coin Magnet
            PlayerPrefs.SetInt("Duration Magnet", 5);
            PlayerPrefs.SetInt("Level Magnet", 1);
            PlayerPrefs.SetInt("Cost Magnet", 300);

            //Shield
            PlayerPrefs.SetInt("Duration Shield", 5);
            PlayerPrefs.SetInt("Level Shield", 1);
            PlayerPrefs.SetInt("Cost Shield", 100);
        }

        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();


        SignIn(true);
        
     
    }

    public void SignInCallback(bool success)
    {
        if(success)
        {
            Debug.Log("Signed in!");
        }
        else
        {
            Debug.Log("Sign-in failed");
            
        }
    }

    public void SignIn(bool silentBool)
    {
        if(!PlayGamesPlatform.Instance.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.Authenticate(SignInCallback, silentBool);
        }
        /*else
        {
            PlayGamesPlatform.Instance.SignOut();
        }*/
    }


    /// <summary>
    /// The Game Manager
    /// </summary>

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
       
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
        AdMob.AdScoreBonus = 0;
        FindObjectOfType<AdMob>().RequestInterstitial();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene");
        AdMob.AdScoreBonus = 0;
        
        FindObjectOfType<AdMob>().RequestInterstitial();
        FindObjectOfType<AdMob>().DestroyBanner();
    }

    public void OpenShop()
    {
    
        SceneManager.LoadScene("ShopScene");
        FindObjectOfType<AdMob>().ShowBannerAD();

    }

    public void OpenOptions()
    {
        
        SceneManager.LoadScene("OptionsMenu");
    }

    public void ShowLeaderboard()
    {
        if(PlayGamesPlatform.Instance.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.ShowLeaderboardUI(GPGSIds.leaderboard_highscore);
        }
        else
        {
            Debug.Log("Failed to show leaderboard");
            SignIn(false);
        }
    }

    public static void AddScoreToLeaderboard(string LeaderboardId, long score)
    {
        Social.ReportScore(score, LeaderboardId, (bool succes) => { });
    }

    public void Back()
    {
        SceneManager.LoadScene("StartMenu");
        FindObjectOfType<AdMob>().DestroyBanner();

        if (Time.timeScale == 0f)
            Time.timeScale = 1f;
    }


    public void QuitGame()
    {
        Application.Quit();
    }

    public void Pause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0f;

        GameObject Player = GameObject.Find("Player");
        Player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        Player.GetComponent<Spawner>().enabled = false;
        Player.GetComponent<SpawnerCoin>().enabled = false;
        Player.GetComponent<SpawnerPowerUps>().enabled = false;

        GameObject Antagonist = GameObject.Find("Antagonist");
        Antagonist.GetComponent<CatchPlayer>().enabled = false;

        GameObject CamFollow = GameObject.Find("CamFollow");
        CamFollow.GetComponent<FollowPlayer>().enabled = false;
    }

    public void Resume()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1f;

        GameObject Player = GameObject.Find("Player");
        Player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        Player.GetComponent<Spawner>().enabled = true;
        Player.GetComponent<SpawnerCoin>().enabled = true;
        Player.GetComponent<SpawnerPowerUps>().enabled = true;

        GameObject Antagonist = GameObject.Find("Antagonist");
        Antagonist.GetComponent<CatchPlayer>().enabled = true;

        GameObject CamFollow = GameObject.Find("CamFollow");
        CamFollow.GetComponent<FollowPlayer>().enabled = true;
    }

    public void NoThanksButton_GameOverScene()
    {
        GameObject.Find("Continue Panel").SetActive(false);
        GameObject.Find("Continue Background").SetActive(false);
    }

    public void ContinueReward_Paid()
    {
        int ContinueCost = 200;
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - ContinueCost);

        SceneManager.LoadScene("GameScene");
        AdMob.AdScoreBonus = PlayerPrefs.GetInt("CurrentScore");
        AdMob.watchedAd = 1;


    }


}
