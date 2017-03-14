using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {
	Animator anim;
	SpriteRenderer rend;
	public GameObject pairGate;

	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator> ();
		rend = gameObject.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (CompareTag (other.GetComponent<SetupLocalPlayer>().colorString)) {
			GetComponent<AudioSource> ().Play ();
			anim.SetBool ("isPressed", !anim.GetBool ("isPressed"));
			pairGate.GetComponent<GateController> ().Toggle ();
		}
	}
}
