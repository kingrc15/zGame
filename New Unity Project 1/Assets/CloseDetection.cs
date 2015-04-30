using UnityEngine;
using System.Collections;

public class CloseDetection : MonoBehaviour {
	public bool trigger;

	// Use this for initialization
	void Start () {
		trigger = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			trigger = true;
		}
	}

	void OnTriggerExit(Collider other){
		if(other.tag == "Player"){
			trigger = false;
		}
	}
}
