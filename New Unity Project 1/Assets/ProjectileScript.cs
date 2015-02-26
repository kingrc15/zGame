using UnityEngine;
using System.Collections;

public class ProjectileScript : MonoBehaviour {
	public PlayerScript player;
	public float ProjectileSpeed;
	Vector3 target;

	// Use this for initialization
	void Start () {
		target = player.look;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (target);
		transform.position = Vector3.MoveTowards (transform.position, target, Time.deltaTime * ProjectileSpeed);
		transform.LookAt(target);
	}

	void OnCollisionEnter(Collision other){
		Destroy (gameObject);
	}
}
