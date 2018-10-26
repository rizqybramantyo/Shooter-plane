using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleCreate : MonoBehaviour {

	public GameObject enemy;
	public float generateTime= 10;
	public float currentTime= 0;

	void Start () {
		CreateEnemyWave();
	}

	void Update(){
		currentTime += Time.deltaTime;
		if(currentTime >= generateTime){
			currentTime = 0;
			CreateEnemyWave();
		}
	}

	void CreateEnemyWave(){
		for(int i =0;i<10;i++){
			float RandomPosX = 8 + i + (Random.Range (0, 30));
			float RandomPosY = Random.Range (-4, 5);

			var cloneEnemy= Instantiate (enemy, new Vector2(RandomPosX,RandomPosY), Quaternion.identity, enemy.transform.parent);

			Destroy (cloneEnemy, RandomPosX);
		}	
	}
}
