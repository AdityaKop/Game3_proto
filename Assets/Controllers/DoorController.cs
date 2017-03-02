using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorController : MonoBehaviour {
	public GameObject partner;
	public Text popup;
	//Vector3 offset = new Vector3(0f, -1.3f, 0f);
	private bool canTP = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		//other.transform.position = partner.transform.position + offset;
		//if (canTP)
		popup.enabled = true;
	}

	void OnTriggerStay2D(Collider2D other) {
		if (Input.GetKeyDown(KeyCode.Space)) {
			other.transform.position = partner.transform.position;
			//partner.GetComponent<DoorController>().canTP = false;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		popup.enabled = false;
		//canTP = true;
	}
}
