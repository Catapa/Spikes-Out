using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsPopUp : MonoBehaviour{

    public Text message;

    public void ShowText()
    {
        if (message.enabled == false)
            message.enabled = true;
        else
            message.enabled = false;
    }

}
