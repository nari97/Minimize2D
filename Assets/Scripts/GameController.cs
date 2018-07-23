using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public GameObject gameOverText;


	public static GameController gc;
	public bool gameOver = false;
	// Use this for initialization
	void Awake () {
		if (gc == null)
			gc = this;
		else if (gc != null)
			Destroy (gameObject);
	}
	
	// Update is called once per frame
	void Update () {

		if (gameOver && Input.GetKey (KeyCode.Space)) {
			SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
		}
		
	}

	public void deadMan (){
		gameOverText.SetActive (true);
		gameOver = true;
	}
}
