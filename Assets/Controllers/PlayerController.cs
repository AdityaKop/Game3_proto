using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	
	public float walkSpeed = 4;

	void Start()
	{
		
	}

	void FixedUpdate()
	{
		if (Input.GetKey ("up") || Input.GetKey(KeyCode.W))
			transform.Translate (0, walkSpeed * Time.deltaTime, 0);
		if (Input.GetKey ("down") || Input.GetKey(KeyCode.S))
			transform.Translate (0, -walkSpeed * Time.deltaTime, 0);
		if (Input.GetKey ("left") || Input.GetKey(KeyCode.A))
			transform.Translate (-walkSpeed * Time.deltaTime, 0, 0);
		if (Input.GetKey ("right") || Input.GetKey(KeyCode.D))
			transform.Translate (walkSpeed * Time.deltaTime, 0, 0);
	}
}
