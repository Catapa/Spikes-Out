using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInFadeOut : MonoBehaviour
{
    float blinkProgress = 0f;
    float blinkStep = 0.05f;
    Text blinkingText;

    void Start()
    {
        blinkingText = gameObject.GetComponent<Text>();
    }
    void Update()
    {
        if ((blinkProgress > 1) || (blinkProgress < 0))
        {
            blinkStep *= -1f;
        }
        blinkProgress += blinkStep;
        blinkingText.color = Color.Lerp(Color.black, Color.white, blinkProgress);// or whatever color you choose

    }
}
