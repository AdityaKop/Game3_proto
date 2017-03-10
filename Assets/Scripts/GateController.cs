using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour {
	Animator anim;
	BoxCollider2D coll;

	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator> ();
		coll = gameObject.GetComponent<BoxCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Toggle() {
		anim.SetBool ("isOpen", !anim.GetBool ("isOpen"));
		coll.enabled = !coll.enabled;
	}
}
