using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	public float speed, FireRate;
	public CameraScript camera;
	public GameObject arrow;
	float movementX, movementZ, timer;
	public Vector3 look;
	public bool allowFire;

	// Use this for initialization
	void Start () {
		timer = FireRate;
		allowFire = true;
	}
	
	// Update is called once per frame
	void Update(){
		if (Input.GetMouseButton (0) && allowFire) {
			Fire ();
		}
	}

	void FixedUpdate () {
		bool movement = camera.movement;
		if(movement){
			movementX = -speed * Input.GetAxis ("Vertical");
			movementZ = speed * Input.GetAxis ("Horizontal");
			rigidbody.velocity = new Vector3 (movementX,0,movementZ);
		}
		else{
			rigidbody.velocity = new Vector3 (0,0,0);
		}
		Aim ();
	}

	IEnumerator Wait(){
		yield return new WaitForSeconds(FireRate);
	}

	void Aim(){	
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit)){
			look = new Vector3(hit.point.x, transform.position.y, hit.point.z);
			transform.LookAt(look);
		}
	}

	void Fire(){
		allowFire = false;
		Transform target = transform.Find("Cube");
		Instantiate(arrow, target.position, Quaternion.identity);
		StartCoroutine(Wait ());
		allowFire = true;
	}
}
