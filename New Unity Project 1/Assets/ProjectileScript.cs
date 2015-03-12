using UnityEngine;
using System.Collections;

public class ProjectileScript : MonoBehaviour {
	public float ProjectileSpeed, range;
	GameObject player;
	Vector3 target, origin;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		origin = player.transform.position;
		target = player.GetComponent<PlayerScript> ().look;
		transform.LookAt(target);
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (target);
		this.gameObject.transform.position += ProjectileSpeed * this.gameObject.transform.forward;
		float dis = Mathf.Sqrt (Mathf.Pow ((this.gameObject.transform.position.x - origin.x), 2) + Mathf.Pow ((this.gameObject.transform.position.z - origin.z), 2));
		if (dis > range) {
			Destroy(gameObject);
		}
	}

	void OnCollisionEnter(Collision other){
		Destroy (gameObject);
	}
}
