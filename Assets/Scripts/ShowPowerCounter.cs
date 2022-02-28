using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPowerCounter : MonoBehaviour {

    public Text Counter;
    public string PowerUpName;
	
	// Update is called once per frame
	void Update () {
        Counter.text = PlayerPrefs.GetInt(PowerUpName).ToString();
	}
}
