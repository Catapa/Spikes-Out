using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	public GameObject player;
	public float smoothing = 1f;
	
	Vector3 offset = new Vector3(0, 5, 0);
	void Start()
	{
		
		offset = (transform.position - player.transform.position) + offset;
	}
	void FixedUpdate ()
	{
		if(player.transform.position.y < 15)
		{
			Vector2 playerCamPos = player.transform.position + offset;
			transform.position = new Vector3(transform.position.x, transform.position.y, -10);
			transform.position = Vector3.Lerp(transform.position, playerCamPos, smoothing * Time.deltaTime * 2);
		}

		if ((transform.position.y > player.transform.position.y + 1) /*|| (transform.position.x > player.transform.position.x + 4) || (transform.position.x < player.transform.position.x - 4)*/ ) smoothing += Time.deltaTime;
		else if(smoothing > 1f)smoothing -= Time.deltaTime;

		//transform.Translate(0f, -Time.deltaTime * 10, 0f);
		
	}


  

}
