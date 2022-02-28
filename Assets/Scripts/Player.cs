using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public Rigidbody2D PlayerRB;
    public int maxSpeed;
    public Text instructionsText;
    public GameObject playerBody;


    public GameObject Enemy;

    private bool isGameStarted = false;
    void Start()
    {
        
        if (AdMob.watchedAd == 1)
            GameObject.Find("Spikes - StartPlatform").SetActive(false);
        else
            GameObject.Find("Spikes - StartPlatform").SetActive(true);

        //Reset platform obstacle to initial size
        //gameObject.GetComponent<Spawner>().enemies[0].gameObject.transform.localScale = new Vector3(1.25f, 1.25f, 1);

        //Reset circle obstacle to initial size
        //gameObject.GetComponent<Spawner>().enemies[1].gameObject.transform.localScale = new Vector3(1.25f, 1.25f, 1);
    }

    void Update()
    {


        if (Mathf.Abs(PlayerRB.velocity.y) >= maxSpeed)
        {
            PlayerRB.AddForce(new Vector3(0.0f, -2.5f * Physics2D.gravity.y, 0.0f));
            Debug.Log("Max speed reached");
        }
        //Activate spawners during gameplay
        if (PlayerPrefs.GetInt("CurrentScore") >= 150) gameObject.GetComponent<RotatorSpinesSpawner>().enabled = true;
        if (PlayerPrefs.GetInt("CurrentScore") >= 350) gameObject.GetComponent<SpinesWheelSpawner>().enabled = true;

        //Increase size of circle obstacle during gameplay
       // if (PlayerPrefs.GetInt("CurrentScore") == 100) gameObject.GetComponent<Spawner>().enemies[1].gameObject.transform.localScale = new Vector3(1.5f, 1.5f, 1);
        //if (PlayerPrefs.GetInt("CurrentScore") == 200) gameObject.GetComponent<Spawner>().enemies[1].gameObject.transform.localScale = new Vector3(2,2,1);


        //Increase size of circle obstacle during gameplay
       // if (PlayerPrefs.GetInt("CurrentScore") == 75) gameObject.GetComponent<Spawner>().enemies[0].gameObject.transform.localScale = new Vector3(1.5f, 1.5f, 1);
      //  if (PlayerPrefs.GetInt("CurrentScore") == 175) gameObject.GetComponent<Spawner>().enemies[0].gameObject.transform.localScale = new Vector3(2, 2, 1);

        if (!isGameStarted && Input.GetMouseButtonDown(0))
        {
            PlayerRB.bodyType = RigidbodyType2D.Dynamic;
            gameObject.GetComponent<Spawner>().enabled = true;
            gameObject.GetComponent<SpawnerCoin>().enabled = true;
            gameObject.GetComponent<SpawnerPowerUps>().enabled = true;
            
            instructionsText.enabled = false;
            Enemy.GetComponent<CatchPlayer>().enabled = true;
            isGameStarted = true;
           
        }
    }



}
