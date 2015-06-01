using UnityEngine;
using System.Collections;

public class Scene5WillowBacktrack : MonoBehaviour {

	GameObject globalObject;
	guiDraw guiScript;
	
	public GameObject rooster;
	public GameObject movingRooster;
	public GameObject rooster2;
	public GameObject hen;
	public GameObject henDead;
	public GameObject wreaths;
	public GameObject wreathsAnim;
	public GameObject apple;
	public GameObject water;
	public GameObject water2;

	bool drawWreaths, drawNoLittleHen;

	// Scene Functions
	void scene_5_1_roosterHitsTree () {
		hen.SetActive(true);
		hen.GetComponent<unanimActor>().actorChangeMoodState("Derp");
		movingRooster.GetComponent<Rigidbody>().isKinematic = false;
		movingRooster.GetComponent<Rigidbody>().detectCollisions = true;
	}

	void scene_5_1_theWreaths () {
		drawWreaths = true;
		hen.SetActive(false);
	}


	void scene_5_1_theWreathsdone () {
		drawWreaths = false;
	}

	void scene_5_1_wreathFalls () {
		wreaths.SetActive(true);
	}

	void scene_5_1_wreathForApple () {
		drawWreaths = false;
		apple.SetActive(false);
		movingRooster.SetActive(false);
		rooster.SetActive(true);
		rooster.GetComponent<unanimActor>().actorChangeMoodState("Excited");
		rooster.GetComponent<Rigidbody>().isKinematic = false;
		rooster.GetComponent<Rigidbody>().detectCollisions = true;
	}

	void scene_5_1_transformWreath () {
		;
	}

	void scene_5_1_transformWreathDone () {
		wreathsAnim.SetActive(false);
		apple.SetActive(true);
	}

	void scene_5_1_transformApple () {
		//apple.GetComponent<unanimActor>().actorChangeMoodState("Derp");
	}
	
	void scene_5_1_transformAppleDone () {
		apple.SetActive(false);
		rooster.GetComponent<unanimActor>().actorChangeMoodState("None");
	}

	void scene_5_2_roosterRemembers () {
		rooster.GetComponent<unanimActor>().actorChangeMoodState("None");
		movingRooster.SetActive(true);
	}

	void scene_5_4_henChokingStill () {
		hen.SetActive(true);
		rooster2.SetActive(true);
		water2.SetActive(true);
		hen.GetComponent<unanimActor>().actorChangeMoodState("Derp");
	}

	void scene_5_4_henDies () {
		hen.SetActive(false);
		henDead.SetActive(true);
	}

	void scene_5_5_noLittleHen () {
		rooster2.SetActive(false);
		rooster.GetComponent<unanimActor>().actorChangeMoodState("Angry");
		drawNoLittleHen = true;
	}

	void scene_5_5_noLittleHenAgain () {
		drawNoLittleHen = false;
	}

	// Scene Done
	void sceneDone () {
		drawNoLittleHen = false;
		globalObject.GetComponent<globalScript>().toggleSceneDone();
	}

	// Use this for initialization
	void Start () {
		// Initialize Global Object and GUI Script in Global Object
		globalObject = GameObject.FindGameObjectWithTag("Global");
		guiScript = globalObject.GetComponent<guiDraw>();
		guiScript.enabled = false;

		rooster2.SetActive(false);
		wreaths.SetActive(false);
		henDead.SetActive(false);
		water2.SetActive(false);

		drawWreaths = drawNoLittleHen = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (drawNoLittleHen) {
			guiScript.drawNoLittleHen = true;
		} else {
			guiScript.drawNoLittleHen = false;
		}

		if (drawWreaths) {
			guiScript.drawWreaths = true;
		} else {
			guiScript.drawWreaths = false;
		}

		if (drawWreaths || drawNoLittleHen)
			guiScript.enabled = true;
		else
			guiScript.enabled = false;
	}
}
