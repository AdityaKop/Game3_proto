using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {
	Animator anim;
	public GameObject pairGate;

	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag (tag)) {
			GetComponent<AudioSource> ().Play ();
			anim.SetBool ("isPressed", !anim.GetBool ("isPressed"));
			pairGate.GetComponent<GateController> ().Toggle ();
		}
	}
}
