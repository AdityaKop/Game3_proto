using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMovementController : NetworkBehaviour {

	Animator anim;

	void Start () {
		if (isLocalPlayer) {
			anim = gameObject.GetComponent<Animator> ();
		}
	}

	void Update () {

		if (!isLocalPlayer) {
			return;
		}

		float InputX = Input.GetAxisRaw ("Horizontal");
		float InputY = Input.GetAxisRaw ("Vertical");

		Vector3 movement = new Vector3 (2 * InputX, 2 * InputY, 0);

		movement *= Time.deltaTime;

		if (InputX != 0 || InputY != 0) {
			anim.SetBool ("isWalking", true);
			setPlayerDirectionAnim (InputX, InputY);
		}
		else {
			anim.SetBool ("isWalking", false);
		}

		transform.Translate(movement);
	}

	void FixedUpdate () {

		if (!isLocalPlayer) {
			return;
		}

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