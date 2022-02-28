/*using System.Collections;
using System.Collections.Generic;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;

public class GooglePlayScript : MonoBehaviour {

	
	public static void Start ()
    {
        //PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        //PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();
        //OnConnectionResponse(PlayGamesPlatform.Instance.localUser.authenticated); // check if user is connected to google play (you have to write the function)

        SignIn();
	}

    static void SignIn()
    {
        Social.localUser.Authenticate((bool succes) => { });
    }


  
        
    public static void AddScoreToLeaderboard(string LeaderboardId, long score)
    {
        Social.ReportScore(score, LeaderboardId, (bool succes) => { });
    }

    public static void ShowLeaderboard()
    {
        if (Social.localUser.authenticated)
            Social.ShowLeaderboardUI();
        

    }

   public void OnConnectClick()
    {
        Social.localUser.Authenticate((bool succes) => {});
    }

  

}*/