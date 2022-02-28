using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreCounter : MonoBehaviour {

    public Transform player;
    public Text scoreText;


    private double score;
    private double deltaPos;

    

    void Start()  // Doar o data la inceputul jocului
    {
        //PlayerPrefs.SetInt("PlayerY", 0);  // Se seteaza pozitia pe Y a player-ului
        PlayerPrefs.SetFloat("PlayerY", 0f);
        PlayerPrefs.SetInt("CurrentScore", 0); // La fel si scorul

        score += 11;  // La inceputul jocului player-ul e la pozitia y = -11, deci scorul il aducem la 0
        score += AdMob.AdScoreBonus;  // Se atribuie bonusul din ad-ul de continue
    }

    void Update() // La fiecare frame
    {
        //score = PlayerPrefs.GetInt("CurrentScore");     ---- Aici era problema, ceapa mâne-si-i...

        //score = ((-1) * (player.position.y - 11) * 0.5)  + ShowAds.AdScoreBonus; // Asa calculez in mod normal scorul, fara multiplier
        // ScoreMultiplier.scoreMultiplier2X   -- asta e variabila in care stochez multiplier-ul
        
        score += (PlayerPrefs.GetFloat("PlayerY") - player.position.y) * ScoreMultiplier.scoreMultiplier2X;
        
        PlayerPrefs.SetFloat("PlayerY", player.position.y);  // Aici doar actualizam pozitia playerului
        PlayerPrefs.SetInt("CurrentScore", (int)score);     // Aici scorul
        scoreText.text = "Score: " + PlayerPrefs.GetInt("CurrentScore").ToString("0");
        

       /* if(score >= PlayerPrefs.GetInt("Highscore",0))
        {
            PlayerPrefs.SetInt("Highscore", (int)score);
           
        }*/
        
    }
}
