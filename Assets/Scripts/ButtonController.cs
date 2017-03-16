using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {
	Animator anim;
	SpriteRenderer rend;
	public GameObject pairGate;
	public GameObject trail;
	private GameObject iTrail = null;
	private float dist;

	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator> ();
		rend = gameObject.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (iTrail == null)
			return;
		if (iTrail.transform.position != pairGate.transform.position) {
			iTrail.transform.position = Vector3.MoveTowards (iTrail.transform.position, pairGate.transform.position, Mathf.Max(dist, 4.0f) * Time.deltaTime);
		} else {
			pairGate.GetComponent<GateController> ().Toggle ();
			Destroy (iTrail, 1.0f);
			iTrail = null;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (CompareTag (other.GetComponent<SetupLocalPlayer>().colorString)) {
			GetComponent<AudioSource> ().Play ();
			anim.SetBool ("isPressed", !anim.GetBool ("isPressed"));
			//pairGate.GetComponent<GateController> ().Toggle ();
			dist = Vector3.Distance(transform.position, pairGate.transform.position);
			iTrail = Instantiate(trail, new Vector3(transform.position.x, transform.position.y, transform.position.z) , Quaternion.identity, transform);
		}
	}
}
