using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CameraController : MonoBehaviour {

	// Use this for initialization
	void Start () {
			Camera.main.transform.position = gameObject.transform.position + new Vector3 (0, 0, -10);
			Camera.main.transform.parent = gameObject.transform;
	}
}
