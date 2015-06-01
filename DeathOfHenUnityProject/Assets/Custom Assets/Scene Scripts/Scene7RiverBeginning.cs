using UnityEngine;
using System.Collections;

public class Scene7RiverBeginning : MonoBehaviour {

	GameObject globalObject;
	guiDraw guiScript;
	bool howToCross, iCanBeBridge, whatIfIBridge;

	public GameObject rooster;
	public GameObject wheat;
	public GameObject mouse1;
	public GameObject mouse2;
	public GameObject mouse3;
	public GameObject mouse4;
	public GameObject mouse5;
	public GameObject mouse6;
	public GameObject coal;
	public GameObject smoke;
	public GameObject mainWagon;
	public GameObject rocks;

	// Scene Functions
	void scene_7_1_wagonMoving () {
		mainWagon.GetComponent<unanimActor>().actorChangeMoodState("Excited");
		RenderSettings.fog = true;
	}

	void scene_7_2_wagonMoving () {
		mainWagon.GetComponent<unanimActor>().actorChangeMoodState("Excited");
	}

	void scene_7_2_wagonStop () {
		mainWagon.GetComponent<unanimActor>().actorChangeMoodState("None");
	}

	void scene_7_3_roosterAsksHow () {
		rooster.GetComponent<unanimActor>().actorChangeMoodState("Angry");
		howToCross = true;
	}

	void scene_7_3_roosterStopTalking () {
		rooster.GetComponent<unanimActor>().actorChangeMoodState("None");
		howToCross = false;
	}

	void scene_7_4_wheatCanBridge () {
		howToCross = false;
		wheat.GetComponent<unanimActor>().actorChangeMoodState("Excited");
		iCanBeBridge = true;
	}

	void scene_7_4_wheatStopTalking () {
		wheat.GetComponent<unanimActor>().actorChangeMoodState("None");
		iCanBeBridge = false;
	}

	void scene_7_5_miceWalk () {
		iCanBeBridge = false;
		wheat.GetComponent<unanimActor>().actorChangeMoodState("None");
		mouse1.GetComponent<unanimActor>().actorChangeMoodState("None");
		mouse2.GetComponent<unanimActor>().actorChangeMoodState("None");
		mouse3.GetComponent<unanimActor>().actorChangeMoodState("None");
		mouse4.GetComponent<unanimActor>().actorChangeMoodState("None");
		mouse5.GetComponent<unanimActor>().actorChangeMoodState("None");
		mouse6.GetComponent<unanimActor>().actorChangeMoodState("None");
	}

	void scene_7_5_miceDie () {
		mouse1.GetComponent<unanimActor>().actorChangeMoodState("Derp");
		mouse2.GetComponent<unanimActor>().actorChangeMoodState("Derp");
		mouse3.GetComponent<unanimActor>().actorChangeMoodState("Derp");
		mouse4.GetComponent<unanimActor>().actorChangeMoodState("Derp");
		mouse5.GetComponent<unanimActor>().actorChangeMoodState("Derp");
		mouse6.GetComponent<unanimActor>().actorChangeMoodState("Derp");
	}

	void scene_7_6_coalCanBridge () {
		coal.GetComponent<unanimActor>().actorChangeMoodState("Excited");
		whatIfIBridge = true;
		wheat.SetActive(false);
		mouse1.SetActive(false);
		mouse2.SetActive(false);
		mouse3.SetActive(false);
		mouse4.SetActive(false);
		mouse5.SetActive(false);
		mouse6.SetActive(false);
	}

	void scene_7_6_coalStopTalking () {
		coal.GetComponent<unanimActor>().actorChangeMoodState("None");
		whatIfIBridge = false;
	}

	void scene_7_7_coalMoving () {
		whatIfIBridge = false;
		coal.GetComponent<unanimActor>().actorChangeMoodState("None");
		wheat.SetActive(false);
		mouse1.SetActive(false);
		mouse2.SetActive(false);
		mouse3.SetActive(false);
		mouse4.SetActive(false);
		mouse5.SetActive(false);
		mouse6.SetActive(false);
	}

	void scene_7_7_coalDie () {
		coal.GetComponent<unanimActor>().actorChangeMoodState("Derp");
		smoke.SetActive(true);
	}

	void scene_7_8_almostTurnAround () {
		rooster.SetActive(false);
		coal.SetActive(false);
		smoke.SetActive(false);
	}

	void scene_7_9_seeRocks () {
		rocks.SetActive(true);
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
		howToCross = iCanBeBridge = whatIfIBridge = false;


		// Set Fog
		RenderSettings.fog = true;
		rocks.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (howToCross)
			guiScript.drawHowToCross = true;
		else
			guiScript.drawHowToCross = false;
		
		if (iCanBeBridge)
			guiScript.drawICanBridge = true;
		else
			guiScript.drawICanBridge = false;

		if (whatIfIBridge)
			guiScript.drawWhatIfCoal = true;
		else
			guiScript.drawWhatIfCoal = false;

		if (howToCross || iCanBeBridge || whatIfIBridge)
			guiScript.enabled = true;
		else
			guiScript.enabled = false;
	}
}
