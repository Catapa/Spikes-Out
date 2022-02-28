using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButtonsManager : MonoBehaviour {

    /*public struct ShopButton
    {
        public Button button;
        public int price;
    }

    public ShopButton buyButtons;*/

    Button[] buyButtons;
    

    private int currentIndex;

    void Start()
    {
        buyButtons = GameObject.FindObjectsOfType<Button>();
    }
    void Update()
    {
        currentIndex = 0;
        foreach(Button button in buyButtons)
        {
            Debug.Log(button.name);
            if (button.name != "BackButton")
                if (
                    PlayerPrefs.GetInt("Coins") < PlayerPrefs.GetInt("Cost " + button.name) ||
                    PlayerPrefs.GetInt("Level " + button.name) >= 10
                    )
                    button.interactable = false;
            currentIndex++;
        }
    }
}
