using UnityEngine;
using System.Collections;

public class spikeTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter (Collider other){
		if (other.gameObject.tag == "Player"){
			Destroy (other.gameObject);
			Debug.Log ("working");
		}
	}
}
