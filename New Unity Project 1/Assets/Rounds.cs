using UnityEngine;
using System.Collections;

public class Rounds : MonoBehaviour {
	public int roundNumber;
	int enemyCount;

	// Use this for initialization
	void Start () {
		roundNumber = 1;
	}
	
	// Update is called once per frame
	void Update () {
		CreateEnemies
	}

	void createEnemies(int enemyNum){
		spawnPoints = FindGameObjectWithTag("SouthRoom"+"NorthRoom"+"EastRoom"+"WestRoom");
		
		instantiate(Enemy, spawnPoints(Random.Range(0,spawnPoints.Length)),Quaternion.identity);

	}
}
