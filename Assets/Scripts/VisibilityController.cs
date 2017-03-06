using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibilityController : MonoBehaviour {
	private float alpha = 0;
	private bool active = false;

	// Use this for initialization
	void Start () {
		GetComponent<SpriteRenderer> ().color = new Color(1f, 1f, 1f, alpha);
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (alpha);
		if (alpha < 1 && active) {
			alpha += 0.1f;
			GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, alpha);
		} else if (alpha > 0 && !active) {
			alpha -= 0.1f;
			GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, alpha);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("hi");
		//GetComponent<Renderer> ().enabled = true;
		active = true;
	}

	void OnTriggerExit2D(Collider2D other) {
		Debug.Log ("bye");
		//GetComponent<Renderer> ().enabled = false;
		active = false;
	}
}
