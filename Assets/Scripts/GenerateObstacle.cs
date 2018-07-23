using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateObstacle : MonoBehaviour {

	private class obstacles{
		public GameObject obs { get; set; }
		//public int x {get; set;}
		public bool onScreen { get; set; }
	}


	obstacles[] ob = new obstacles[10];

	public GameObject obs;
	public GameObject cam;
	//public GameObject gr;
	private float posY;
	private int x;
	private float minPosY;
	// Use this for initialization
	void Start () {
		x = 0;
		minPosY = -4.6f;
		/*for (x = 5; x <= 95; x += 15) {
			y = Random.Range(0.0f,3.0f);
			Debug.Log (y.ToString ());
			posY = minPosY + y;
			Instantiate (obs, new Vector2 (x, posY), Quaternion.identity);
		}*/


		for (int i = 0; i < 10; ++i) {
			ob [i] = new obstacles ();
			ob [i].obs = Instantiate(obs,new Vector3(0,0,2.53f),Quaternion.identity);
			ob [i].onScreen = false;
		}




	}

	void setOnScreen(){

		for (int i = 0; i < 10; ++i) {
			if (cam.transform.position.x - 50 > ob [i].obs.transform.position.x && ob[i].onScreen == true)
				ob [i].onScreen = false;
		}
	}
	// Update is called once per frame
	void Update () {
		float y = 0;

		//float zRot = 0;
		setOnScreen ();
		for (int i = 0; i < 10; ++i) {
			if (ob [i].onScreen == false) {
				y = Random.Range (0.0f, 3.5f);
				posY = minPosY + y;
				x +=Random.Range(22,30);
				//Instantiate (ob [i].obs, new Vector2 (x, posY), Quaternion.identity);
				ob[i].obs.transform.position = new Vector3(x,posY,2.53f);

				//x += 22;
				ob [i].onScreen = true;
				break;
			}
		}
	}
}
