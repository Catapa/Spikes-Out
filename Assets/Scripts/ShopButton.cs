using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour {

    public int price;
    public Button buyButton;
    public Text ObjectPrice;
    public Text TotalCoins;
    public string ObjectName;
    public Text counter;

 

	void Start ()
    {
        ObjectPrice.text = price.ToString();
        //PlayerPrefs.SetInt("Coins", 2000);
     


    }
	
	public void Buy()
    {
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - price);
        TotalCoins.text = PlayerPrefs.GetInt("Coins").ToString();
        PlayerPrefs.SetInt(ObjectName, PlayerPrefs.GetInt(ObjectName) + 1);
        
    }


	void Update ()
    {
        if (PlayerPrefs.GetInt(ObjectName) >= 3) buyButton.interactable = false;
        counter.text = "(" + PlayerPrefs.GetInt(ObjectName) + "/3)";
    }
}
