using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMultiplier : MonoBehaviour {

   // public Text scoreText;
    public static double scoreMultiplier2X = 1;
    public double duration;

    GameObject scoreTextObject;
    Text scoreText;

    void Start()
    {
        //if (PlayerPrefs.GetInt("2X Score") <= 0) PowerUpButton.interactable = false;
       
    }

    void Update()
    {
        scoreTextObject = GameObject.Find("ScoreText");
        scoreText = scoreTextObject.GetComponent<Text>();

        duration -= Time.deltaTime;
     
        if (duration <= 0)
        {
            scoreText.color = Color.black;
            scoreMultiplier2X = 1;
            //if (PlayerPrefs.GetInt("2X Score") > 0) PowerUpButton.interactable = true;
        }
            

    }

	public void ScoreMultiplier2X()
    {
        scoreTextObject = GameObject.Find("ScoreText");
        scoreText = scoreTextObject.GetComponent<Text>();

        //PowerUpButton.interactable = false;
        duration = PlayerPrefs.GetInt("Duration 2X Multiplier");
        Debug.Log("2X MULTIPLIER for " + duration + " seconds");
        
        scoreText.color = Color.red;

        scoreMultiplier2X = 2;
       // PlayerPrefs.SetInt("2X Score", PlayerPrefs.GetInt("2X Score") - 1);
      
        Update();
    }
}
