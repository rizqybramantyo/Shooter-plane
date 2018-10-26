using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {
	public float speedX = 0.8f;
	public float speedY = 0.8f;
	public Vector2 movement;

	public float generateTime;
	private float currentTime;

	public GameObject bullet;

	void Start () {
		currentTime -= Random.Range (2,5);
	}

	void Update () {
		GetComponent<Rigidbody2D>().velocity= new Vector2(speedX * movement.x, speedY * movement.y);


		currentTime += Time.deltaTime;
		if (currentTime >= generateTime) {
			Shoot ();
			currentTime = 0;
			generateTime = Random.Range (3, 5);
		}
	}

	void Shoot(){
		var cloneBullet = Instantiate (bullet, 
			new Vector2 (transform.localPosition.x, transform.localPosition.y), Quaternion.identity, bullet.transform.parent);
		    Destroy (cloneBullet.gameObject, 2);
	}

}
