using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;

public class SetScoreText : MonoBehaviour {

    public Text ScoreText; 
    int CurrentScore;

	void Start ()
    {
       
        CurrentScore = PlayerPrefs.GetInt("CurrentScore");

        if(CurrentScore > PlayerPrefs.GetInt("Highscore"))
        {
            ScoreText.text = "New Highscore: " + CurrentScore.ToString();
            PlayerPrefs.SetInt("Highscore", CurrentScore);
            //ReportHighscore();
            GameStateManager.AddScoreToLeaderboard(GPGSIds.leaderboard_highscore, PlayerPrefs.GetInt("Highscore"));

        }
        else
        {
            ScoreText.text = "Score: " + CurrentScore.ToString();
        }
        
	}

    /*void ReportHighscore()
    {
        if (PlayGamesPlatform.Instance.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.ReportScore(PlayerPrefs.GetInt("Highscore"), GPGSIds.leaderboard_leaderboard, (bool success) => { });
        }
    }*/

}
