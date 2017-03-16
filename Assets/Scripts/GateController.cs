using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GateController : NetworkBehaviour {
	Animator anim;
	BoxCollider2D coll;

	[SyncVar]
	public bool open;

	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator> ();
		coll = gameObject.GetComponent<BoxCollider2D> ();
		if (open)
			Toggle ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Toggle() {
		open = !open;
		anim.SetBool ("isOpen", open);
		coll.enabled = !open;
	}
}
