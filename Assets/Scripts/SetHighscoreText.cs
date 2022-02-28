using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetHighscoreText : MonoBehaviour {

    public Text HighscoreText;
    int currentHighscore;

	void Start ()
    {
        currentHighscore = PlayerPrefs.GetInt("Highscore", 0);
        HighscoreText.text = "Highscore: " + currentHighscore.ToString();
	}
	
}
