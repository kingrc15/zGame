using UnityEngine;
using System.Collections;

public class RoomScript : MonoBehaviour {
	public GameObject room;
	bool onTrigger;
	GameObject roomIn;

	// Use this for initialization
	void Start () {
		onTrigger = false;
		roomIn = Instantiate(room, new Vector3(0,0,0), Quaternion.identity) as GameObject;
	}


	// Update is called once per frame
	void Update () {
		roomIn = GetRoom ();
	}


	void OnTriggerEnter(Collider other){
		CreateRoom (other);
	}

	public GameObject GetRoom(){
		GameObject Room = room;
		GameObject[] y = GameObject.FindGameObjectsWithTag("Room");
		float minX = 50, minZ = 70;

		foreach (GameObject x in y) {
			if(Mathf.Abs(transform.position.x - x.transform.position.x) <= minX && Mathf.Abs(transform.position.z - x.transform.position.z) <= minZ){					
				Room = x;
				Color color = x.transform.renderer.material.color;
				color.a = 1f;
				x.transform.renderer.material.color = color;
				minX = Mathf.Abs(transform.position.x - x.transform.position.x);
				minZ = Mathf.Abs(transform.position.z - x.transform.position.z);
			}
			else{
				Color color = x.transform.renderer.material.color;
				color.a = 0.5f;
				x.transform.renderer.material.color = color;
			}
		}

		return Room;
	}


	void CreateRoom(Collider other){
		Vector3 nextPosition = nextRoom (other, roomIn);

		if (roomTest (nextPosition)) {
			Instantiate (room, nextPosition, Quaternion.identity);
		}

		destroyTriggers ();
	}

	Vector3[] roomTrack(){
		GameObject[] rooms = GameObject.FindGameObjectsWithTag("Room");
		Vector3[] roomArr = new Vector3[50];
		int i = 0;

		foreach (GameObject x in rooms) {
			roomArr[i] = x.transform.position;
			i++;
		}

		return roomArr;
	}

	bool roomTest(Vector3 newPosition){
		bool goodRoom = true;
		Vector3[] newRoom = roomTrack ();

		for (int i = 0; i < 50; i++) {
			if(newRoom[i] == newPosition){
				goodRoom = false;
			}
		}

		return goodRoom;
	}

	Vector3 nextRoom(Collider other, GameObject roomIn){
		Vector3 newPosition = new Vector3 (0,0,0);

		if (other.tag == "NorthRoom" && !onTrigger) {
			newPosition =  roomIn.transform.position + new Vector3 (-90, 0, 0);
		}
		else if (other.tag == "SouthRoom" && !onTrigger) {
			newPosition = roomIn.transform.position + new Vector3 (90, 0, 0);

		}
		else if (other.tag == "EastRoom" && !onTrigger) {
			newPosition = roomIn.transform.position + new Vector3 (0, 0, 140);
		}
		else if (other.tag == "WestRoom" && !onTrigger) {
			newPosition = roomIn.transform.position + new Vector3 (0, 0, -140);
		}

		return newPosition;
	}

	void destroyTriggers(){
		GameObject[] northRooms = GameObject.FindGameObjectsWithTag ("NorthRoom");
		GameObject[] southRooms = GameObject.FindGameObjectsWithTag ("SouthRoom");
		GameObject[] eastRooms = GameObject.FindGameObjectsWithTag ("EastRoom");
		GameObject[] westRooms = GameObject.FindGameObjectsWithTag ("WestRoom");

		foreach (GameObject x in northRooms) {
			foreach (GameObject y in southRooms){
				if(Mathf.Abs(x.transform.position.x - y.transform.position.x) <= 20f && Mathf.Abs(x.transform.position.z - y.transform.position.z) <= 20f){
					Destroy(x);
					Destroy(y);
				}
			}
		}

		foreach (GameObject x in eastRooms) {
			foreach (GameObject y in westRooms){
				if(Mathf.Abs (x.transform.position.x - y.transform.position.x) <= 50f && Mathf.Abs(x.transform.position.z - y.transform.position.z) <= 50f){
					Destroy(x);
					Destroy(y);
				}
			}
		}
	}



}
