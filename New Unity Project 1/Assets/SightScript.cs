using UnityEngine;
using System.Collections;

public class SightScript : MonoBehaviour {
	public bool found;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Transform enemy = GetComponentInParent<EnemyScript> ().transform;
		RaycastHit hit;
		Ray sight = new Ray (enemy.position, -transform.forward);

		if(Physics.Raycast(sight, out hit, Mathf.Infinity)){
			transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, hit.distance/4.0f);
			transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localScale.z);
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			found = true;
		}
	}

	void OnTriggerExit(Collider other){
		if (other.tag == "Player") {
			found = false;
		}
	}
}
