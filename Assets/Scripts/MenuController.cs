using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class MenuController : MonoBehaviour {

	public void LoadScene(int sceneToLoad)
	{
		SceneManager.LoadSceneAsync (sceneToLoad, LoadSceneMode.Single);
	}

	public void QuitGame()
	{
		Application.Quit ();
	}
}
