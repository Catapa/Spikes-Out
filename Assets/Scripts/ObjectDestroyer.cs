using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour {

    GameObject ObstacleDestroyerPoint;

    void Start()
    {
        ObstacleDestroyerPoint = GameObject.Find("ObstacleDestroyerPoint");
    }
    void Update ()
    {
        if (transform.position.y >= ObstacleDestroyerPoint.transform.position.y + 100 && gameObject.tag == "Coin")
            Destroy(gameObject);
        else if (transform.position.y >= ObstacleDestroyerPoint.transform.position.y && gameObject.tag != "Coin")
            Destroy(gameObject);
	}
}
