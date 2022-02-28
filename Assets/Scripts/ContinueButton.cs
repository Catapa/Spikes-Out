using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueButton : MonoBehaviour {

    public GameObject continuePanel;

	void Start () {

        if (PlayerPrefs.GetInt("Coins") < 200)
            GameObject.Find("Pay To Continue Button").GetComponent<Button>().interactable = false;

        if ((PlayerPrefs.GetInt("CurrentScore") < 50) || (AdMob.watchedAd == 1))
        {
            GameObject.Find("Continue Background").SetActive(false);
            continuePanel.SetActive(false);
            AdMob.watchedAd = 0;
        }
	}

    public void SetAdReward_Continue()
    {
        AdMob.RewardType = "Continue";
    }


}
