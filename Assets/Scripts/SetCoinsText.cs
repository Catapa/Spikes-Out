using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetCoinsText : MonoBehaviour {


    public Text coinsText;

  
	// Use this for initialization
	void Update () {
     
        coinsText.text = PlayerPrefs.GetInt("Coins", 500).ToString();
	}
	

}
