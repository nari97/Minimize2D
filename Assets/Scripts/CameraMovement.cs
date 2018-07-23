using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	// Use this for initialization
	public static CameraMovement cm;
	//public GameObject player;
	///Vector3 offset;
	//Vector3 prevPos;
	private bool deadManGuy = false;
	private float camSpeed = 0.18f;
	void Start () {
		
		cm = this;
		//offset = transform.position- player.transform.position;
		//prevPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		if (!deadManGuy) {
			float x = transform.position.x + camSpeed;
			transform.position = new Vector3 (x, transform.position.y, transform.position.z);
		}
		//if (cameraPos.x < prevPos.x)
			//transform.position = prevPos;
		//else
		//	transform.position = cameraPos;

		//prevPos = transform.position;
	}

	public void deadMan(){
		deadManGuy = true;
	}
}
