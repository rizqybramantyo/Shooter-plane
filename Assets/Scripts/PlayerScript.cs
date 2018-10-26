using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour {
	public float speedX = 0.8f;
	public float speedY = 0.8f;
	private Vector2 movement;
	public GameObject bullet;
	public float generateTime= 1;
	private float currentTime= 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float inputX=0, inputY=0;

		if (Input.GetKey (KeyCode.UpArrow)) {
			inputY = 1;
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			inputY = -1;
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			inputX = -1;
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			inputX = 1;
		}
			
		currentTime += Time.deltaTime;

		if (Input.GetKeyDown (KeyCode.Space)) {
			if (currentTime >= generateTime) {
				var cloneBullet = Instantiate (bullet, 
				new Vector2 (transform.localPosition.x, transform.localPosition.y), Quaternion.identity, bullet.transform.parent);
				Destroy (cloneBullet.gameObject, 8);
				currentTime = 0;
			}
		}

		GetComponent<Rigidbody2D> ().velocity = new Vector2 (
			speedX * inputX, speedY * inputY
		);

	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.name.Contains ("poulpi")) {
			SceneManager.LoadScene ("Gameplay");
		}
	}
}
