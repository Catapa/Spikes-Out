using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachMiscToObjectsPosition: MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ObjectToFollow;
    public float smoothing = 0f;
    public bool DestroyWithObject = false;
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //gameObject.transform.position = ObjectToFollow.transform.position;

        //transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        transform.position = Vector3.Lerp(transform.position, new Vector3(ObjectToFollow.transform.position.x, ObjectToFollow.transform.position.y, -1), smoothing * Time.deltaTime);
        DestroyIfObjectDestroyed();
    }

    void DestroyIfObjectDestroyed()
    {
        if (DestroyWithObject)
        {
            if(!ObjectToFollow.activeInHierarchy)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
