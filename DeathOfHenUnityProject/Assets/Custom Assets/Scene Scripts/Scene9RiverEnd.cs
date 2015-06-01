using UnityEngine;
using System.Collections;

public class Scene9RiverEnd : MonoBehaviour {

	GameObject globalObject;
	guiDraw guiScript;
	bool noRooster;

	public GameObject rooster;
	public GameObject roosterWithHen;
	public GameObject henDead;
	public GameObject wagon;
	public GameObject wagonAnim;

	// Scene Functions
	void scene_9_1_roosterSeeLand () {
		RenderSettings.fog = true;
		rooster.GetComponent<unanimActor>().actorChangeMoodState("Excited");
	}

	void scene_9_2_roosterMovingOn () {
		rooster.SetActive(true);
		rooster.GetComponent<unanimActor>().actorChangeMoodState("Excited");
	}

	void scene_9_2_roosterTurnsAround () {
		rooster.GetComponent<unanimActor>().actorChangeMoodState("None");
	}

	void scene_9_3_backflip () {
		rooster.GetComponent<unanimActor>().actorChangeMoodState("None");
	}

	void scene_9_4_roosterScreamsNo () {
		rooster.SetActive(true);
		rooster.GetComponent<unanimActor>().actorChangeMoodState("Angry");
		noRooster = true;
	}

	void scene_9_4_roosterStopsScreaming () {
		noRooster = false;
	}

	void scene_9_5_bouncingWagon () {
		noRooster = false;
		rooster.SetActive(false);
		wagon.SetActive(true);
		wagon.GetComponent<unanimActor>().actorChangeMoodState("Derp");
	}

	void scene_9_6_movingOn () {
		rooster.SetActive(false);
		wagon.SetActive(false);
		roosterWithHen.GetComponent<unanimActor>().actorChangeMoodState("Angry");
	}

	void sceneFadeOut () {
		gameObject.GetComponent<screenFader>().StartFade(new Color(0,0,0,1), 4.0f);
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
		noRooster = false;

		rooster.SetActive(false);
		wagon.SetActive(false);

		RenderSettings.fog = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (noRooster)
			guiScript.drawNoRoosterScream = true;
		else
			guiScript.drawNoRoosterScream = false;

		if (noRooster)
			guiScript.enabled = true;
		else
			guiScript.enabled = false;
	}
}
