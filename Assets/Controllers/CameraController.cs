using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public Transform player;
	Vector3 offset = new Vector3(0, 0, -10);

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (player.position.x + offset.x, 
			player.position.y + offset.y, offset.z); // Camera follows the player with specified offset position
	}
}
