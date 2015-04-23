using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public int startinghealth;
	public int healthperheart;

	public GUITexture heartGUI;

	// Use this for initialization
	void Start () {
		AddHearts (startinghealth / healthperheart);
	}

	public void AddHearts(int n) {
		for (int i =0; i < n; i ++) {
				Instantiate (heartGUI.gameObject);
			}

	}

	public void ModifyHealth (int amount) {

	}
}
