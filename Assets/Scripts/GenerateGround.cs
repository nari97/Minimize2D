using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGround : MonoBehaviour {

	private class ground{
		public GameObject gr {get; set;}
		public bool onScreen {get; set;}
	}

	ground[] g = new ground[3];
	public GameObject gr;
	public GameObject cam;
	// Use this for initialization
	void Start () {

		for (int i = 0; i < 3; ++i) {
			g [i] = new ground ();
			g [i].gr = Instantiate (gr, new Vector2 (0, 0), Quaternion.identity);
			g [i].onScreen = false;
		}

		g [1].gr.transform.position = new Vector2 (90f+45f, -4.89f);
		g [1].onScreen = true;
	}

	void setOnScreen(){
		for(int i=2;i>=0;--i){
			if(cam.transform.position.x-20>g[i].gr.transform.position.x)
				g[i].onScreen = false;
		}
	}
	// Update is called once per frame
	void Update () {
	
		setOnScreen ();
		for (int i = 2; i >= 0; --i) {
			//Debug.Log (g [i].onScreen.ToString ());
			if (g [i].onScreen == false) {
				g [i].gr.transform.position = new Vector2 (cam.transform.position.x + 45, -4.89f);
				g [i].onScreen = true;
				break;
			}
		}
	}
}
