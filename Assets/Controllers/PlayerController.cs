using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	
	private int frameDelay = 4;
	private int playerSpeed = 5;
	private Color[] data;
	private SpriteRenderer mapSprite;
	private int width, height;
	private bool up, down, left, right;

	public GameObject map;

	void Start()
	{
		mapSprite = map.GetComponent<SpriteRenderer> ();
		width = mapSprite.sprite.texture.width;
		height = mapSprite.sprite.texture.height;
		data = mapSprite.sprite.texture.GetPixels();
		Debug.Log (data.Length);
	}

	void FixedUpdate()
	{
		Vector3 screenPos = transform.position;    
		screenPos = new Vector2(screenPos.x, screenPos.y);

		if (frameDelay <= 0) {
			if (Input.GetKey ("up") || Input.GetKey (KeyCode.W)) {
				up = true;
				screenPos += new Vector3 (0f, 0.32f, 0f);
			}
			if (Input.GetKey ("down") || Input.GetKey (KeyCode.S)) {
				down = true;
				screenPos -= new Vector3 (0f, 0.32f, 0f);
			}
			if (Input.GetKey ("left") || Input.GetKey (KeyCode.A)) {
				left = true;
				screenPos -= new Vector3 (0.32f, 0f, 0f);
			}
			if (Input.GetKey ("right") || Input.GetKey (KeyCode.D)) {
				right = true;
				screenPos += new Vector3 (0.32f, 0f, 0f);
			}
			Color color;
			//Debug.Log (screenPos);
			RaycastHit2D[] ray = Physics2D.RaycastAll(screenPos, Vector2.zero, 0.01f);
			for (int i = 0; i < ray.Length; i++)
			{
				// You will want to tag the image you want to lookup
				if (ray[i].collider.tag == "Map")
				{ 
					// Set click position to the gameobject area
					screenPos -= ray[i].collider.gameObject.transform.position;
					int x = (int)(screenPos.x * width);
					int y = (int)(screenPos.y * height) + height;
					Debug.Log (x);
					Debug.Log (y);
					// Get color data
					if (x > 0 && x < width && y > 0 && y < height)
					{
						color = data[y * width + x];
						Debug.Log (color);
					}                 
					break;
				}
			}
			frameDelay = 4;
		} else if (frameDelay > 0) {
			if (up)
				transform.Translate (0f, 0.08f, 0f);
			if (down)
				transform.Translate (0f, -0.08f, 0f);
			if (left)
				transform.Translate (-0.08f, 0f, 0f);
			if (right)
				transform.Translate (0.08f, 0f, 0f);
			--frameDelay;
		}
		if (frameDelay == 0) up = down = left = right = false;
		/*transform.Translate (playerSpeed * Input.GetAxis ("Horizontal") * Time.deltaTime, 0f, 0f);
		transform.Translate (0f, playerSpeed * Input.GetAxis ("Vertical") * Time.deltaTime, 0f);*/
	}
}
