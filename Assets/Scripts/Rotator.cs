using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float speed = 1;
    float direction = 1;

    void Start()
    {
        if (gameObject.name != "Antagonist")
        {
            speed = SetSpeed(1, 7);
            direction = SetDirection();
        }
    }

    void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, 45f * direction) * Time.deltaTime * speed);
    }

    float SetSpeed(float minimumSpeed, float maximumSpeed)
    {
        Random.InitState((int)Time.time);
        float speed = Random.Range(minimumSpeed, maximumSpeed);
        return speed;
    }

    int SetDirection()
    {
        Random.InitState((int)Time.time);
        int direction;
        int randomResult = Random.Range(0, 2);
        if (randomResult == 0)
            direction = 1;
        else
            direction = -1;
        
        return direction;
    }
}
