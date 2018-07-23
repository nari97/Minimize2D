using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour {

	Rigidbody2D rb;
	public GameObject cam;
	public Text score;
	public float jumpHeight = 5.0f;
	public float moveSpeed = 0.01f;
	private bool isGrounded = true;
	private float t;
	private bool deadManGuy = false;
	private Animator animator;
	private int minTime = 3;
	private Vector3 maxSize;
	private Vector3 minSize;
	private float currentTime;
	private bool minFlag = false;
	private float goingOutScreen = 1.0f;
	// Use this for initialization
	void Start () {
	
		rb = GetComponent<Rigidbody2D> ();
		maxSize = transform.localScale;
		minSize = maxSize / 2;

		animator = GetComponent<Animator> ();
	}
		

	void OnCollisionStay2D(Collision2D col){

		//if (!isGrounded)
			//maximize ();
		//Debug.Log ("Collision".ToString ());
		//Comment to enable obstacles
		/*if (col.gameObject.tag == "Obstacle") {
			//Debug.Log ("Colliding with Obs");
			deadManGuy = true;
			GameController.gc.deadMan ();
		}*/


		if (col.gameObject.tag == "Obstacle") {
			rb.gravityScale = 5;
			moveSpeed = 0.6f;
		} else {
			moveSpeed = 0.5f;
			rb.gravityScale = 1;
		}
		//if (col.gameObject.tag == "ground") {
			//Debug.Log ("Colliding with ground");
			isGrounded = true;
		//}
	}
	// Update is called once per frame


	void maximize(){
		jumpHeight = 5.0f;
		minFlag = false;
		transform.localScale = maxSize;
	}

	void minimize(){
		jumpHeight = 7.5f;
		minFlag = true;
		if(transform.localScale == maxSize)
			t = Time.time;
		transform.localScale =minSize;
	}

	void OnGUI(){
		GUIStyle myStyle = new GUIStyle ();
		myStyle.fontSize = 30;
		//myStyle.font = 
		if(minFlag && !deadManGuy)
			GUI.Label (new Rect (560, 25, 610, 75), (t + minTime - currentTime).ToString("F2"),myStyle);
	}

	void Update () {

		currentTime = Time.time;

		//animator.SetTrigger ("PlayerIdle");

		int campos = (int)cam.transform.position.x;
		score.text = "Score : " + campos.ToString ();

		if (!deadManGuy) {
			if (currentTime >= t + minTime)
				maximize ();
			//else {
			//	OnGUI ();
			//}

			if (Input.GetKey (KeyCode.Space) && isGrounded && transform.position.y<=3.77) {
				rb.AddForce (Vector2.up * jumpHeight, ForceMode2D.Impulse);
				minimize ();
				isGrounded = false;
				animator.SetTrigger ("PlayerIdle");
			}

			if (transform.position.y >= 3.77)
				transform.position = new Vector2 (transform.position.x, 3.77f);


			if (transform.position.x < cam.transform.position.x - 15) {
				deadManGuy = true;
				GameController.gc.deadMan ();
				CameraMovement.cm.deadMan ();
			}

			if (transform.position.x > cam.transform.position.x + 11)
				goingOutScreen = 0.7f;
			else
				goingOutScreen = 1.0f;
			/*
			if (Input.GetKey (KeyCode.LeftControl)) {
				minimize ();
			}*/


			//Uncomment for returning to normal


			//if (isGrounded == false)
			//	animator.SetTrigger ("PlayerIdle");
			/*if (Input.GetKey (KeyCode.RightArrow)) {
				rb.AddForce (Vector2.right * moveSpeed, ForceMode2D.Impulse);
	
				if (isGrounded)
					animator.SetTrigger ("PlayerWalk");
			}
			if (transform.position.x < cam.transform.position.x - 11) {
			} else {
				if (Input.GetKey (KeyCode.LeftArrow)) {
					rb.AddForce (Vector2.left * moveSpeed, ForceMode2D.Impulse);
					if (isGrounded)
						animator.SetTrigger ("PlayerWalk");
				}
			}*/


			//Comment to return to normal
			rb.AddForce (Vector2.right * moveSpeed*goingOutScreen, ForceMode2D.Impulse);

			//if (isGrounded)
				//animator.SetTrigger ("PlayerWalk");

		}
	}
}
