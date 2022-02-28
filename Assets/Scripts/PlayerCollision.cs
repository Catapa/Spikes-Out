using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GooglePlayGames;


public class PlayerCollision : MonoBehaviour
{
    public GameObject explosionEffect;
    public GameObject shield;

    private shake shake;

    void Start()
    {
        shake = GameObject.FindGameObjectWithTag("CameraShake").GetComponent<shake>();
        FindObjectOfType<AdMob>().RequestBanner();
    }

    void OnCollisionEnter2D(Collision2D colliderInfo)
    {
        if (colliderInfo.collider.tag == "Obstacle")
        {
            if(shield.activeInHierarchy == true)
            {
                GameObject[] CurrentObstacles = GameObject.FindGameObjectsWithTag("Obstacle");
                foreach (GameObject obstacle in CurrentObstacles)
                {
                   Instantiate(explosionEffect, obstacle.transform.position, obstacle.transform.rotation);
                    if(obstacle.name != "Antagonist")
                        Destroy(obstacle);

                    FindObjectOfType<AudioManager>().Play("PlayerDeath");
                    shake.CamShake();
                }
    
                shield.SetActive(false);
            }
            else
            {
                Instantiate(explosionEffect, transform.position, transform.rotation);
                gameObject.SetActive(false);
                FindObjectOfType<AudioManager>().Play("PlayerDeath");
                shake.CamShake();
                Invoke("GameOver", 1.5f);
            }
           

        }

       
    }



    void GameOver()
    {
        if (PlayerPrefs.GetInt("CurrentScore") >= 40 /*&& PlayerPrefs.GetInt("WatchedAds")<5*/ )
        {
            FindObjectOfType<AdMob>().ShowInterstitialAd();
            FindObjectOfType<AdMob>().ShowBannerAD();
            PlayerPrefs.SetInt("WatchedAds", PlayerPrefs.GetInt("WatchedAds") + 1);
        }
        else
        {
            FindObjectOfType<AdMob>().ShowBannerAD();
            PlayerPrefs.SetInt("WatchedAds", 0);
        }

        Debug.Log("Game Over!");
        //GameStateManager.AddScoreToLeaderboard(GPGSIds.leaderboard_highscore, PlayerPrefs.GetInt(""));
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        


    }
    
    

}
