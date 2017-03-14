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
		/*if (rend.material.color.a < 0.99) {
			rend.material.color += new Color (0f, 0f, 0f, 0.1f);
		}*/
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (CompareTag (other.GetComponent<SetupLocalPlayer>().colorString)) {
			GetComponent<AudioSource> ().Play ();
			anim.SetBool ("isPressed", !anim.GetBool ("isPressed"));
			pairGate.GetComponent<GateController> ().Toggle ();
			//rend.material.color -= new Color (0f, 0f, 0f, 0.9f);
		}
	}
}
