using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomizeButtonsManager : MonoBehaviour {

	public CustomizeButton[] buttons;
    public Text coinsAmount;

    private int totalCoins;

  


    void Start()
    {
        
        
        /*foreach(CustomizeButton button in buttons)
        {
            PlayerPrefs.SetInt("ModelBought" + button.ModelNumber, 0);
        }*/
        PlayerPrefs.SetInt("ModelBought"+0, 1);
    }
	
	// Update is called once per frame
	void Update () {

        coinsAmount.text = PlayerPrefs.GetInt("Coins",500).ToString();
        totalCoins = PlayerPrefs.GetInt("Coins");

        foreach (CustomizeButton button in buttons)
        {
           

            // We check if the current button is equiped
            if (PlayerPrefs.GetInt("ModelNumber") == button.ModelNumber)
            {
                button.text.text = "Equiped";
                button.text.color = Color.yellow;
                button.coin.enabled = false;
            }

            // If not...
            else
            {
                //We check if it's bought
                if (PlayerPrefs.GetInt("ModelBought" + button.ModelNumber) == 1)
                {
                    button.text.text = "Equip";
                    button.coin.enabled = false;
                    button.text.color = Color.white;
                }
                //Or not
                if (PlayerPrefs.GetInt("ModelBought" + button.ModelNumber) == 0)
                {

                    if (button.price > totalCoins) button.GetComponent<Button>().interactable = false ;
                    button.text.text = button.price.ToString();
                    button.coin.enabled = true;
                    button.text.color = Color.white;
                }

    
            }
        }
		
	}

   

}
