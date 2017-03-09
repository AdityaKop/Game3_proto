using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour {

	Animator anim;
	public Vector3 startPosition;

	void Start () {
		startPosition = transform.position;
		anim = gameObject.GetComponent<Animator> ();
	}

	void Update () {
		float InputX = Input.GetAxisRaw ("Horizontal");
		float InputY = Input.GetAxisRaw ("Vertical");

		Vector3 movement = new Vector3 (
			2 * InputX,
			2 * InputY,
			0);

		movement *= Time.deltaTime;

		if (Input.GetButton ("Horizontal") || Input.GetButton ("Vertical")) {
			anim.SetBool ("isWalking", true);
			setPlayerDirectionAnim(InputX, InputY);
		} else {
			anim.SetBool ("isWalking", false);
		}

		transform.Translate(movement);
	}

	void FixedUpdate () {
		float lastInputX = Input.GetAxisRaw ("Horizontal");
		float lastInputY = Input.GetAxisRaw ("Vertical");

		if (Input.GetButton ("Horizontal") || Input.GetButton ("Vertical")) {
			anim.SetBool ("isWalking", true);
			if (lastInputX > 0)
				anim.SetFloat ("LastMoveX", 1f);
			else if(lastInputX < 0)
				anim.SetFloat ("LastMoveX", -1f);
			else
				anim.SetFloat ("LastMoveX", 0f);
			if(lastInputY > 0)
				anim.SetFloat ("LastMoveY", 1f);
			else if(lastInputY < 0)
				anim.SetFloat ("LastMoveY", -1f);
			else
				anim.SetFloat ("LastMoveY", 0f);
		} else {
			anim.SetBool ("isWalking", false);
		}
	}

	void setPlayerDirectionAnim(float horizInput, float vertInput) {
		anim.SetFloat ("SpeedX", horizInput);
		anim.SetFloat ("SpeedY", vertInput);
		anim.SetFloat ("LastMoveX", horizInput);
		anim.SetFloat ("LastMoveY", vertInput);
	}
}
