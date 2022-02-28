using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateShield : MonoBehaviour
{

    //public Button PowerUpButton;
    public GameObject shield;

    private double duration;

    void Start()
    {

    }

    void Update()
    {
        duration -= Time.deltaTime;

        if (duration <= 0) shield.SetActive(false);

    }

    public void StartShield()
    {
  
        duration = PlayerPrefs.GetInt("Duration Shield");
        Debug.Log("SHIELD for " + duration + " seconds");
        shield.SetActive(true);


        Update();
    }
}

