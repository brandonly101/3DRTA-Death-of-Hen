using UnityEngine;
using System.Collections;

public class Scene3Well : MonoBehaviour {

	GameObject globalObject;
	guiDraw guiScript;
	
	GameObject rooster;
	GameObject roosterAnim;
	GameObject well;

	bool wellLol, wellGiveWater, getAppleBride;

	// Initialization
	void Start () {
		// Initialize Global Object and GUI Script in Global Object
		globalObject = GameObject.FindGameObjectWithTag("Global");
		guiScript = globalObject.GetComponent<guiDraw>();
		guiScript.enabled = false;

		// Find some objects
		rooster = GameObject.Find("/Scene 3 Well/Rooster");
		roosterAnim = GameObject.Find("/Scene 3 Well/Rooster Anim");

		well = GameObject.Find("/Scene 3 Well/Water Well");

		roosterAnim.SetActive(false);
		wellLol = wellGiveWater = getAppleBride = false;

	}

	// Scene functions
	void scene_3_2 () {
		rooster.SetActive(false);
		roosterAnim.SetActive(true);
		wellLol = true;
		roosterAnim.GetComponent<unanimActor>().actorChangeMoodState("Talking");
	}

	void scene_3_2_1 () {
		wellLol = false;
		roosterAnim.GetComponent<unanimActor>().actorChangeMoodState("None");
	}

	void scene_3_2_2 () {
		wellGiveWater = true;
		roosterAnim.GetComponent<unanimActor>().actorChangeMoodState("Talking");
	}

	void scene_3_2_3 () {
		wellGiveWater = false;
		roosterAnim.GetComponent<unanimActor>().actorChangeMoodState("None");
	}

	void scene_3_2_WellSaysGetApple () {
		getAppleBride = true;
		roosterAnim.GetComponent<unanimActor>().actorChangeMoodState("None");
		well.GetComponent<unanimActor>().actorChangeMoodState("Talking");
	}
	void scene_3_2_WellStopsTalking () {
		getAppleBride = false;
		roosterAnim.GetComponent<unanimActor>().actorChangeMoodState("None");
		well.GetComponent<unanimActor>().actorChangeMoodState("None");
	}
	void scene_3_3_roosterGoesToBride() {
		wellLol = false;
		roosterAnim.GetComponent<unanimActor>().actorChangeMoodState("Derp");
	}

	// Scene Done
	void sceneDone () {
		globalObject.GetComponent<globalScript>().toggleSceneDone();
	}
	
	// Update
	void Update () {
		if (wellLol)
			guiScript.drawWellLol = true;
		else
			guiScript.drawWellLol = false;

		if (wellGiveWater)
			guiScript.drawWellGiveWater = true;
		else
			guiScript.drawWellGiveWater = false;

		if (getAppleBride)
			guiScript.drawGetAppleBride = true;
		else
			guiScript.drawGetAppleBride = false;

		if (wellLol || wellGiveWater || getAppleBride)
			guiScript.enabled = true;
		else
			guiScript.enabled = false;
	}
}
