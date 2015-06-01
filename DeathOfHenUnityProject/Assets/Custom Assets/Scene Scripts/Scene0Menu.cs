using UnityEngine;
using System.Collections;

public class Scene0Menu : MonoBehaviour {

	GameObject globalObject;
	guiDraw guiScript;

	public Texture2D btnTexture;

	// Scene Done
	void sceneDone () {
		globalObject.GetComponent<globalScript>().toggleSceneDone();
	}
	
	// Use this for initialization
	void Start () {
		// Initialize Global Object and GUI Script in Global Object
		globalObject = GameObject.FindGameObjectWithTag("Global");
		guiScript = globalObject.GetComponent<guiDraw>();
		guiScript.enabled = false;
	}

	void OnGUI () {
		GUI.Label(new Rect(
			(float)(Screen.width * 0.1), 
			(float)(Screen.height * 0.1),
			(float)(Screen.width),
			(float)(Screen.height)
			), btnTexture
		);

		if (GUI.Button(new Rect(
				(float)(Screen.width * 0.6), 
			    (float)(Screen.height * 0.8),
			    (float)(Screen.width * 0.2),
			    (float)(Screen.height * 0.1)
			), "Start"))
			sceneDone();
	}
}
