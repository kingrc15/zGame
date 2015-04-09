using UnityEngine;
using System.Collections;

public class DetectionScript : MonoBehaviour {
	public float fieldOfView;
	public bool found;
	public bool triggered;
	Collider obj;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(triggered){
			Sight (obj);
		}
		if(obj != null){
			if (Vector3.Distance (obj.transform.position, transform.position) >= 42) {
				triggered = false;
				found = false;
			}
		}
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == ("Player")){
			triggered = true;
			obj = other;
		}
	}

	void Sight(Collider other){
		Transform enemy = GetComponentInParent<EnemyScript>().transform;
		Vector3 dir = other.transform.position - transform.position;
		Vector3 direction = transform.InverseTransformDirection(dir);
		float playerAngle = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg;
		bool cond = playerAngle <= 90 + fieldOfView / 2 && playerAngle >= 90 - fieldOfView / 2;

		if(cond){
			RaycastHit hit;
			Debug.DrawRay(transform.position, dir, Color.green);
			Ray sight = new Ray (transform.position, dir);
			if(Physics.Raycast(sight, out hit,Mathf.Infinity)){
				if(hit.collider.tag == "Player"){
					found = true;
				}
				else{
					found = false;
				}
			}
		}
	}
}
