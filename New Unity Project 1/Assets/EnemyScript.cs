﻿using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
	public float enemySpeed;
	GameObject player, cam;
	bool movement, playerFound, found;

	// Use this for initialization
	void Start () {
		cam = GameObject.FindGameObjectWithTag ("MainCamera");
	}
	
	// Update is called once per frame
	void LateUpdate () {
		player = GameObject.FindGameObjectWithTag ("Player");
		movement = cam.GetComponent<CameraScript>().movement;
		found = GetComponentInChildren<DetectionScript> ().found || GetComponentInChildren<CloseDetection>().trigger;

		if(movement){
			if(found){
				Destroy ();
			}
			else{
				//Seek ();
			}
		}
		else{
			rigidbody.velocity = new Vector3(0,0,0);
		}

	}

	void Seek(){
		RaycastHit hit;
		transform.Rotate (Vector3.right * Time.deltaTime);
		transform.position = Vector3.MoveTowards (transform.position, Vector3.forward * 5, Time.deltaTime * 20);
	}

	void Destroy(){
		Vector3 dir = Vector3.Normalize(player.transform.position - transform.position);
		transform.LookAt (player.transform.position);
		rigidbody.velocity = dir * enemySpeed;
		Vector3 Dir = Vector3.RotateTowards (transform.position, player.transform.position, 360, 0.0f);
	}
}