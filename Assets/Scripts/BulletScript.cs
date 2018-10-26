using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class BulletScript : MonoBehaviour {
	public float speedX = 0.8f;
	public bool isPlayer = false;


	// Use this for initialization
	void Start () {
				
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (speedX, 0, 0);
	}

	void OnTriggerEnter2D(Collider2D col){
		if (isPlayer == true) {
			if (col.gameObject.name.Contains ("poulpi")) {
				Destroy (col.gameObject);
				Destroy (this.gameObject);
			}
		} else {
			if (col.gameObject.name.Contains ("player")) {
				SceneManager.LoadScene ("Gameplay");
			}
		}
	}
}
	
