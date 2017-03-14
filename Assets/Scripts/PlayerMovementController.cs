using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMovementController : NetworkBehaviour {

	Animator anim;
	Rigidbody2D rb2d;

	private float walkSpeed;
	private float maxSpeed;
	private float curSpeed;

	void Start () {
		if (isLocalPlayer) {
			anim = gameObject.GetComponent<Animator> ();
			rb2d = gameObject.GetComponent<Rigidbody2D> ();
		}

		walkSpeed = 2500f;
	}

	void Update () {

		if (!isLocalPlayer) {
			return;
		}

		float InputX = Input.GetAxisRaw ("Horizontal");
		float InputY = Input.GetAxisRaw ("Vertical");

		if (InputX != 0 || InputY != 0) {
			anim.SetBool ("isWalking", true);
			setPlayerDirectionAnim (InputX, InputY);
		}
		else {
			anim.SetBool ("isWalking", false);
		}
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

		curSpeed = walkSpeed;

		rb2d.velocity = new Vector2(Mathf.Lerp(0, Input.GetAxis("Horizontal")* Time.deltaTime * curSpeed, 0.8f),
			Mathf.Lerp(0, Input.GetAxis("Vertical")* Time.deltaTime * curSpeed, 0.8f));
	}
		
	void setPlayerDirectionAnim(float horizInput, float vertInput) {
		anim.SetFloat ("SpeedX", horizInput);
		anim.SetFloat ("SpeedY", vertInput);
		anim.SetFloat ("LastMoveX", horizInput);
		anim.SetFloat ("LastMoveY", vertInput);
	}
}