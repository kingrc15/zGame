using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
	public float enemySpeed;
	GameObject enemy, player;
	bool movement;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		enemy = GameObject.FindGameObjectWithTag ("Enemy");

		movement = enemy.GetComponent<CameraScript> ().movement;
	}
	
	// Update is called once per frame
	void Update () {
		if(!movement){
			transform.position = Vector3.MoveTowards (transform.position, player.transform.position, enemySpeed * Time.deltaTime);
		}
		else{
			rigidbody.velocity = new Vector3(0,0,0);
		}

	}
}
