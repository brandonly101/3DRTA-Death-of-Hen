using UnityEngine;
using System.Collections;

public class Scene4Princess : MonoBehaviour {

	GameObject globalObject;
	guiDraw guiScript;
	
	public GameObject rooster;
	public GameObject bride;
	
	bool brideGiveApple, getWreathsWillow;

	// Scene Functions

	void scene_4_1_roosterArrives () {
		rooster.GetComponent<unanimActor>().actorChangeMoodState("Derp");
	}

	void scene_4_1_roosterStops () {
		rooster.GetComponent<unanimActor>().actorChangeMoodState("None");
	}

	void scene_4_2_roosterTalks () {
		brideGiveApple = true;
		rooster.GetComponent<unanimActor>().actorChangeMoodState("Talking");
	}

	void scene_4_2_roosterStops () {
		brideGiveApple = false;
		rooster.GetComponent<unanimActor>().actorChangeMoodState("None");
	}

	void scene_4_2_brideTalks () {
		getWreathsWillow = true;
	}

	void scene_4_2_brideStops () {
		getWreathsWillow = false;
	}

	// Scene Done
	void sceneDone () {
		getWreathsWillow = false;
		globalObject.GetComponent<globalScript>().toggleSceneDone();
	}

	// Use this for initialization
	void Start () {
		// Initialize Global Object and GUI Script in Global Object
		globalObject = GameObject.FindGameObjectWithTag("Global");
		guiScript = globalObject.GetComponent<guiDraw>();
		guiScript.enabled = false;

		brideGiveApple = getWreathsWillow = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (brideGiveApple)
			guiScript.drawBrideGiveApple = true;
		else
			guiScript.drawBrideGiveApple = false;

		if (getWreathsWillow)
			guiScript.drawGetWreathsWillow = true;
		else
			guiScript.drawGetWreathsWillow = false;

		if (brideGiveApple || getWreathsWillow)
			guiScript.enabled = true;
		else
			guiScript.enabled = false;

	}
}
