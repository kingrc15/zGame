﻿using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public int startinghealth;
	public int healthperheart;

	public GUITexture heartGUI;

	private ArrayList hearts = new ArrayList();

	public int maxHeartsPerRow;
	private float spacingX;
	private float spacingY;

	// Use this for initialization
	void Start () {
		spacingX = heartGUI.pixelInset.width;
		spacingY = heartGUI.pixelInset.height;

		AddHearts (startinghealth / healthperheart);
	}

	public void AddHearts(int n) {
		for (int i =0; i < n; i ++) {
				Transform newHeart = ((GameObject)Instantiate (heartGUI.gameObject)).transform;
			newHeart.parent = this.transform.parent;

			int y = Mathf.FloorToInt(hearts.Count / maxHeartsPerRow);
			int x = hearts.Count - y * maxHeartsPerRow;

			newHeart.GetComponent<GUITexture>().pixelInset = new Rect(x * spacingX, y * spacingY,58,58);

			hearts.Add (newHeart);
			}

	}

	public void ModifyHealth (int amount) {

	}
}
