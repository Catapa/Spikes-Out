using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorSpinesSpawner : MonoBehaviour
{

    public GameObject[] enemies;
    public Transform player;
    //public Vector2 spawnValues;
    //public float spawnWait;
    //public float spawnMostWait;
    //public float spawnLeastWait;
    //public int startWait;
   // public bool stop;

    int randEnemy;
    float spawnYMin;
    float spawnYMax;


    public int distBetweenSpawns = 30;
    int deltaDist;
    int initialPlayerPosition;

    void Start()
    {
        deltaDist = 0; //
        initialPlayerPosition = (int)player.position.y;//

        //StartCoroutine(WaitSpawner());
    }


    void Update()
    {

        if (PlayerPrefs.GetInt("CurrentScore") >= 400) { distBetweenSpawns = 25; }
        if (PlayerPrefs.GetInt("CurrentScore") >= 600) { distBetweenSpawns = 20; }
        if (PlayerPrefs.GetInt("CurrentScore") >= 900) { distBetweenSpawns = 15; }

        spawnYMin = player.position.y - 20;
        spawnYMax = player.position.y - 30;


        deltaDist = initialPlayerPosition - (int)player.position.y;

        if (deltaDist >= distBetweenSpawns)
        {
            Spawn();
            initialPlayerPosition = (int)player.position.y;
            deltaDist = 0;
        }
    }

    void Spawn()
    {
        // Vector2 spawnPosition = new Vector2(Random.Range(player.position.x - 15, player.position.x + 15), Random.Range(spawnYMin, spawnYMax));
        Vector2 spawnPosition = GetSpawnPosition();
        randEnemy = Random.Range(0, 2);
        Instantiate(enemies[randEnemy], spawnPosition, gameObject.transform.rotation);
    }


    Vector2 GetSpawnPosition()
    {
        Vector2 spawnPosition;
        do
        {
            spawnPosition = new Vector2(Random.Range(player.position.x - 12, player.position.x + 12), Random.Range(spawnYMin, spawnYMax));
        } while (Physics2D.OverlapCircleAll(spawnPosition, 1.5f).Length > 0);
        return spawnPosition;
    }


}
