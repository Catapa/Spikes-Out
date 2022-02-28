using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetPickedCoins : MonoBehaviour {

    public Text pickedCoinsText;
	// Use this for initialization
	void Start () {
        pickedCoinsText.text = PlayerPrefs.GetInt("PickedCoins").ToString();
	}

}
