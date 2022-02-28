using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPowerUps : MonoBehaviour
{

    public GameObject[] PowerUps;
    public Transform player;
    //public Vector2 spawnValues;
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    public int startWait;
    public bool stop;

    int randPowerUp;

    void Start()
    {
        StartCoroutine(WaitSpawner());
    }


    void Update()
    {
        spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
    }

    IEnumerator WaitSpawner()
    {
        yield return new WaitForSeconds(startWait);

        while (!stop)
        {
            randPowerUp = Random.Range(0, PowerUps.Length);

            Vector2 spawnPosition = GetSpawnPosition();

            Instantiate(PowerUps[randPowerUp], spawnPosition, Quaternion.identity);

            yield return new WaitForSeconds(spawnWait);
        }
    }

    Vector2 GetSpawnPosition()
    {
        Vector2 spawnPosition;
        do
        {
            spawnPosition = new Vector2(Random.Range(player.position.x - 12, player.position.x + 12), Random.Range(player.position.y - 10, player.position.y - 20));
        } while (Physics2D.OverlapCircleAll(spawnPosition, 1.75f).Length > 0);
        return spawnPosition;
    }
}
