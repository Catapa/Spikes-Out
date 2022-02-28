using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomizeButton : MonoBehaviour {

    public Text text;
    public int ModelNumber;
    public int price;
    public Image coin;

    

    public void Equip()
    {
        //text.text = "Equiped";
        if (PlayerPrefs.GetInt("ModelBought" + ModelNumber) == 0)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - price);
        }

        PlayerPrefs.SetInt("ModelBought" + ModelNumber, 1);
        PlayerPrefs.SetInt("ModelNumber", ModelNumber);

        
    }
}
