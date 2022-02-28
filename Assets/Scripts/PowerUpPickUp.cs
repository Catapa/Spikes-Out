using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PowerUpPickUp : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "PowerUp_2XScore(Clone)")
        {

            ScoreMultiplier scoreMultiplier = GameObject.Find("ScoreText").GetComponent<ScoreMultiplier>();
            scoreMultiplier.ScoreMultiplier2X();
        }

        if (collision.name == "PowerUp_Magnet(Clone)")
        {
            CoinMagnet coinMagnet = GameObject.Find("CoinMagnet").GetComponent<CoinMagnet>();
            coinMagnet.AtractCoin();
        }

        if (collision.name == "PowerUp_Shield(Clone)")
        {
            ActivateShield activateShield = GameObject.Find("Player").GetComponent<ActivateShield>();
            activateShield.StartShield();
        }

        Destroy(collision.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Time.deltaTime);
    }
}
