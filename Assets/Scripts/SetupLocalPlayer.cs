using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SetupLocalPlayer : NetworkBehaviour {
	
	[SyncVar]
	public Color playerColor;
	[SyncVar]
	public string pname;
	[SyncVar]
	public string colorString;

	Animator anim;
	SpriteRenderer sprit;

	void Start()
	{
		if (isLocalPlayer) {
			GetComponent<PlayerMovementController> ().enabled = true;
			GetComponent<CameraController> ().enabled = true;
		}

		anim = GetComponent<Animator> ();
		sprit = GetComponent<SpriteRenderer> ();

		if (playerColor == Color.blue) {
			sprit.sprite = Resources.Load<Sprite> ("Spritesheets/CharacterBlueBase");
			anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController> ("Animations/PlayerAnimatorBlue");
			gameObject.transform.position = new Vector3 (-11.69f, 12.97f, -1f);
			colorString = "Blue";
		} else if (playerColor == Color.red) {
			sprit.sprite = Resources.Load<Sprite> ("Spritesheets/CharacterRed_1");
			anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController> ("Animations/PlayerAnimatorRed");
			gameObject.transform.position = new Vector3 (-13.25f, 11.38f, -1f);
			colorString = "Red";
		} else if (playerColor == Color.yellow) {
			sprit.sprite = Resources.Load<Sprite> ("Spritesheets/CharacterYellow_1");
			anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController> ("Animations/PlayerAnimatorYellow");
			gameObject.transform.position = new Vector3 (-14.86f, 12.97f, -1f);
			colorString = "Yellow";
		}

		gameObject.GetComponent<NetworkAnimator> ().SetParameterAutoSend (0, true);
		gameObject.GetComponent<NetworkAnimator> ().SetParameterAutoSend (1, true);
		gameObject.GetComponent<NetworkAnimator> ().SetParameterAutoSend (2, true);
		gameObject.GetComponent<NetworkAnimator> ().SetParameterAutoSend (3, true);
		gameObject.GetComponent<NetworkAnimator> ().SetParameterAutoSend (4, true);
		gameObject.GetComponent<NetworkAnimator> ().SetParameterAutoSend (5, true);
	}
}
