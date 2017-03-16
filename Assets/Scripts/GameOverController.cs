using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "WinBox")
		{
			gameObject.GetComponent<PlayerMovementController> ().enabled = false;
			gameObject.transform.GetChild (0).gameObject.SetActive (true);
		}
	}
}
