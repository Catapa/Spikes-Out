using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinPickup : MonoBehaviour {

    public Text coinsAmount;
    //public AudioSource coinSound;
    int amount;
    int pickedAmount;
    int pickedAmountRound;

    void Start()
    {
        amount = PlayerPrefs.GetInt("Coins");
        PlayerPrefs.SetInt("PickedCoins", 0);
        SetCoinsText();
        //coinSound = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Coin"))
        {
            PickUp(other);

            FindObjectOfType<AudioManager>().Play("CoinPickup");
        }
    }

    void PickUp(Collider2D coin)
    {
        pickedAmount = Random.Range(5, 15);
        amount += pickedAmount;
        pickedAmountRound += pickedAmount;
        
        PlayerPrefs.SetInt("Coins", amount);
        PlayerPrefs.SetInt("PickedCoins", pickedAmountRound);
        Destroy(coin.gameObject);
        SetCoinsText();
    }

    void SetCoinsText()
    {
        coinsAmount.text = amount.ToString();
    }

}
