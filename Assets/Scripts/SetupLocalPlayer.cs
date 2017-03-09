using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SetupLocalPlayer : NetworkBehaviour {
	public Color playerColor;
	public string pname;
	public RuntimeAnimatorController redAnim;
	public RuntimeAnimatorController blueAnim;
	public RuntimeAnimatorController yellowAnim;
	public Sprite redSprite;
	public Sprite blueSprite;
	public Sprite yellowSprite;	

	Animator anim;
	SpriteRenderer sprit;

	// Use this for initialization
	void Start () {
		if (isLocalPlayer) {
			anim = GetComponent<Animator> ();
			sprit = GetComponent<SpriteRenderer> ();
			if (playerColor == Color.blue) {
//				anim.runtimeAnimatorController = blueAnim as RuntimeAnimatorController;
//				sprit.sprite = blueSprite as Sprite;
				anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animations/PlayerAnimatorBlue");
			} else if (playerColor == Color.red) {
//				anim.runtimeAnimatorController = redAnim as RuntimeAnimatorController;
//				sprit.sprite = redSprite as Sprite;
				anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animations/PlayerAnimatorRed");
			} else if (playerColor == Color.yellow) {
//				anim.runtimeAnimatorController = yellowAnim as RuntimeAnimatorController;
//				sprit.sprite = yellowSprite as Sprite;
				anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animations/PlayerAnimatorYellow");
			}
		}
	}
}
