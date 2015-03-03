using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
	public GameObject player;
	public RoomScript roomscript;
	public Vector3 offset;
	public bool movement;
	public float transistionSpeed;
	GameObject prevRoom;

	// Use this for initialization
	void Start () {
		prevRoom = roomscript.GetRoom ();
		movement = true;
	}
	
	// Update is called once per frame
	void Update () {
		GameObject room = roomscript.GetRoom ();
		if(prevRoom == room && movement){
			CameraFollow (room);
		}
		else{
			CameraTransistion (room);
		}
		prevRoom = room;
	}

	void CameraFollow(GameObject room){
		transform.LookAt ((player.transform.position - room.transform.position)/ 1.5f + room.transform.position);
		transform.position = (player.transform.position - room.transform.position)/ 1.5f + offset + room.transform.position;
		transform.rotation = transform.rotation * Quaternion.identity;
	}

	void CameraTransistion(GameObject room){
		Vector3 target = (player.transform.position - room.transform.position) / 1.5f + room.transform.position + offset;
		if (transform.position != target) {
			transform.position = Vector3.MoveTowards(transform.position, target, transistionSpeed * Time.deltaTime);
			movement = false;
		}
		else{
			movement = true;
		}

	}
}
