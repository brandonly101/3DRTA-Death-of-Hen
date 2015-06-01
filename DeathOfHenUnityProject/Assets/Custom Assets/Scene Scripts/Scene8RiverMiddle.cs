using UnityEngine;
using System.Collections;

public class Scene8RiverMiddle : MonoBehaviour {

	GameObject globalObject;
	guiDraw guiScript;

	public GameObject finalRock;
	public Transform playerWagon;

	Vector3 localPos;

	public AudioClip wilhelmScream;

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

		localPos = playerWagon.localPosition;

		RenderSettings.fog = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.P)) {
			sceneDone();
		}
		if (playerWagon.localPosition.y < localPos.y - 20) {
			GetComponent<AudioSource>().PlayOneShot(wilhelmScream);
			playerWagon.localPosition = localPos;
		}
	}
}
