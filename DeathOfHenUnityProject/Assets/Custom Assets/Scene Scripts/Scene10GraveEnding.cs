using UnityEngine;
using System.Collections;

public class Scene10GraveEnding : MonoBehaviour {

	GameObject globalObject;
	guiDraw guiScript;
	bool everyoneDead, sadnessGrief;

	public GameObject rooster;
	public GameObject roosterAnim;

	// Scene Functions
	void scene_10_1_roosterGoesToGrave () {
		RenderSettings.fog = false;
		rooster.SetActive(false);
		roosterAnim.GetComponent<unanimActor>().actorChangeMoodState("Sad");
	}

	void scene_10_1_roosterMovesOnTop () {
		roosterAnim.GetComponent<unanimActor>().actorChangeMoodState("Moving");
	}

	void scene_10_1_roosterIsOnTop () {
		roosterAnim.GetComponent<unanimActor>().actorChangeMoodState("Sad");
	}

	void scene_10_2_roosterSaysEveryone () {
		roosterAnim.GetComponent<unanimActor>().actorChangeMoodState("Talking");
		everyoneDead = true;
	}

	void scene_10_2_roosterStopsTalking () {
		roosterAnim.GetComponent<unanimActor>().actorChangeMoodState("Sad");
		everyoneDead = false;
	}

	void scene_10_2_roosterSadnessGrief () {
		roosterAnim.GetComponent<unanimActor>().actorChangeMoodState("Talking");

		sadnessGrief = true;
	}

	void scene_10_2_roosterStopsTalkingAgain () {
		roosterAnim.GetComponent<unanimActor>().actorChangeMoodState("Sad");
		sadnessGrief = false;
	}

	void scene_10_3_roosterDieing () {
		everyoneDead = false;
		sadnessGrief = false;
		roosterAnim.GetComponent<unanimActor>().actorChangeMoodState("Angry");
	}

	void scene_10_3_roosterDies () {
		roosterAnim.SetActive(false);
		rooster.SetActive(true);
	}

	void sceneFadeOut () {
		gameObject.GetComponent<screenFader>().StartFade(new Color(0,0,0,1), 5.0f);
	}
	
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

		rooster.SetActive(false);
		RenderSettings.fog = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (everyoneDead)
			guiScript.drawEveryoneDead = true;
		else
			guiScript.drawEveryoneDead = false;

		if (sadnessGrief)
			guiScript.drawIAmFillingSad = true;
		else
			guiScript.drawIAmFillingSad = false;

		if (everyoneDead || sadnessGrief)
			guiScript.enabled = true;
		else
			guiScript.enabled = false;
	}
}
