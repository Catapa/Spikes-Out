using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchPlayer : MonoBehaviour
{

    public GameObject Player;
    float smoothing = 0.85f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 antagonist = Player.transform.position;
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        transform.position = Vector3.Lerp(transform.position, antagonist, smoothing * Time.deltaTime * 2);
    }
}
