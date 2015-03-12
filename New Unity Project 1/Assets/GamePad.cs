using UnityEngine;
using System.Collections;

public class GamePad : MonoBehaviour {
	public float speed, SpinSpeed;
	public CameraScript cam;
	float movementX, movementZ;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		bool movement = cam.movement;
		float spin = Input.GetAxis (Input.GetJoystickNames()[0]);
		if(movement){
			movementX = -speed * Input.GetAxis ("Vertical");
			movementZ = speed * Input.GetAxis ("Horizontal");
			transform.localRotation = new Quaternion (0,spin * SpinSpeed,0,1);
			rigidbody.velocity = new Vector3 (movementX,0,movementZ);
		}
		else{
			rigidbody.velocity = new Vector3 (0,0,0);
		}
	}
}