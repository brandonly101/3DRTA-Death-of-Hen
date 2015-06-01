using UnityEngine;
using System.Collections;

public class Scene2NutMountainTop : MonoBehaviour {
	
	public GameObject directionalLight;
	public GameObject pointLight;
	public GameObject spotlight;
	public GameObject rooster;
	public GameObject roosterAnimated;
	public GameObject hen;
	public GameObject hen2;
	public GameObject hen3;
	public GameObject henAnimated;
	public GameObject giantPeanut;
	public AudioSource song1;
	
	GameObject globalObject;
	guiDraw guiScript;

	bool moveToPeanut;
	bool drawText;
	bool drawOhNo;
	bool drawGetWater;

	////////////////////////////////////////////////
	// Animation Functions
	//

	// Scene 2 1
	void sceneHenWalksUp () {
		henAnimated.SetActive(true);
		henAnimated.GetComponent<unanimActor>().actorChangeMoodState("Excited and Moving");
	}

	void sceneHenSeesPeanut () {
		henAnimated.GetComponent<unanimActor>().actorChangeMoodState("None");
	}

	// Scene 2 2
	void sceneGiantFloatingPeanut () {
		hen.SetActive(true);
		henAnimated.SetActive(false);
		directionalLight.SetActive (false);
		spotlight.SetActive (true);
		pointLight.SetActive (false);
	}

	// Scene 2 3
	void sceneHenTalk () {
		drawText = true;
		directionalLight.SetActive (true);
		spotlight.SetActive (false);
		pointLight.SetActive (true);
		hen.GetComponent<unanimActor>().actorChangeMoodState("Talking");
	}

	void sceneHenStopTalk () {
		drawText = false;
		hen.GetComponent<unanimActor>().actorChangeMoodState("None");
	}

	// Scene 2 4
	void sceneHenRunToPeanut () {
		moveToPeanut = true;
		hen.GetComponent<unanimActor>().actorChangeMoodState("Excited");
	}

	void sceneHenSwallowing () {
		hen.SetActive(false);
		giantPeanut.SetActive(false);
		hen2.SetActive(true);
	}

	void sceneHenChoking () {
		hen2.GetComponent<unanimActor>().actorChangeMoodState("Derp");
		giantPeanut.SetActive(false);
	}

	// Scene 2 5
	void sceneRoosterSees () {
		rooster.SetActive(true);
		hen2.SetActive(false);
	}

	// Scene 2 6
	void sceneRoosterTalksToHen () {
		drawOhNo = true;
		rooster.SetActive(false);
		roosterAnimated.SetActive(true);
		roosterAnimated.GetComponent<unanimActor>().actorChangeMoodState("Talking");
	}

	void sceneRoosterFinishesTalking () {
		roosterAnimated.GetComponent<unanimActor>().actorChangeMoodState("None");
		drawOhNo = false;
	}

	// Scene 2 7
	void sceneHenTalksToRooster () {
		drawOhNo = false;
		drawGetWater = true;
		hen3.SetActive(true);
		hen3.GetComponent<unanimActor>().actorChangeMoodState("Derp");
	}

	void sceneHenFinishesTalking () {
		drawGetWater = false;
	}

	// Scene 2 8
	void sceneRoosterFlies() {
		drawGetWater = false;
		roosterAnimated.GetComponent<unanimActor>().actorChangeMoodState("None");
	}

	// Scene Done
	void sceneDone () {
		globalObject.GetComponent<globalScript>().toggleSceneDone();
	}

	////////////////////////////////////////////////
	// Rendering functions (Start () and Update ())
	////////////////////////////////////////////////
	void Start () {
		// Initialize Global Object and GUI Script in Global Object
		globalObject = GameObject.FindGameObjectWithTag("Global");
		guiScript = globalObject.GetComponent<guiDraw>();
		guiScript.enabled = false;

		// Deactivate actor(s) at specific points initially
		hen.SetActive(false);
		hen2.SetActive(false);
		hen3.SetActive(false);
		rooster.SetActive(false);
		roosterAnimated.SetActive(false);

		drawText = false;
		drawOhNo = false;
		drawGetWater = false;

		LightmapSettings.lightmaps = new LightmapData[]{};
	}

	void Update () {
		if (moveToPeanut)
			hen.transform.position = 
				Vector3.MoveTowards(hen.transform.position, giantPeanut.transform.position, Time.deltaTime * 14);

		if (drawText)
			guiScript.drawText = true;
		else
			guiScript.drawText = false;
		
		if (drawOhNo)
			guiScript.drawOhNo = true;
		else
			guiScript.drawOhNo = false;
		
		if (drawGetWater)
			guiScript.drawGetWater = true;
		else
			guiScript.drawGetWater = false;

		if (drawText || drawOhNo || drawGetWater)
			guiScript.enabled = true;
		else
			guiScript.enabled = false;

	}
}
