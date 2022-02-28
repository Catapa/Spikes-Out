using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinMagnet : MonoBehaviour {

    //public Button PowerUpButton;
    public Transform player;
    public float speed;

    private double duration;

    void Start()
    {
       // if (PlayerPrefs.GetInt("Coin Magnet") <= 0) PowerUpButton.interactable = false;
    }

    void Update()
    {
        duration -= Time.deltaTime;

        GameObject[] CurrentCoins = GameObject.FindGameObjectsWithTag("Coin");

        


        if (duration <= 0)
        {
        
            //if (PlayerPrefs.GetInt("Coin Magnet") > 0) PowerUpButton.interactable = true;
        }
        else
            foreach (GameObject coin in CurrentCoins)
            {
                if (coin.GetComponent<FloatingEffect>().enabled == true)
                    coin.GetComponent<FloatingEffect>().enabled = false;

                coin.transform.position = Vector2.MoveTowards(coin.transform.position, player.transform.position, speed * Time.deltaTime);
            }



    }

    public void AtractCoin()
    {
        duration = PlayerPrefs.GetInt("Duration Magnet");
        Debug.Log("MAGNET for: " + duration + " seconds!!!");
        Update();
    }
}

