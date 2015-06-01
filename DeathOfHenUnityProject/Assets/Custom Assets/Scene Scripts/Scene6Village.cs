using UnityEngine;
using System.Collections;

public class Scene6Village : MonoBehaviour {

	GameObject globalObject;
	guiDraw guiScript;
	bool drawWagon, drawCanWeCome, drawOk;

	public GameObject rooster;
	public GameObject roosterAnim;
	public GameObject henDead;

	public GameObject mice1;
	public GameObject mice2;
	public GameObject mice3;
	public GameObject mice4;
	public GameObject mice5;
	public GameObject mice6;

	public GameObject fox;
	public GameObject wolf;
	public GameObject bear;
	public GameObject elk;
	public GameObject dog;
	public GameObject robot;
	public GameObject horse1;
	public GameObject horse2;

	public GameObject wagon;
	public GameObject wagonWithAnimals;

	public GameObject smoke;

	// Scene Functions
	void scene_6_1_roosterCrashLanding () {
		// Make everyone sad
		rooster.GetComponent<unanimActor>().actorChangeMoodState("Derp");
		mice1.GetComponent<unanimActor>().actorChangeMoodState("Derp");
		mice2.GetComponent<unanimActor>().actorChangeMoodState("Derp");
		mice3.GetComponent<unanimActor>().actorChangeMoodState("Derp");
		mice4.GetComponent<unanimActor>().actorChangeMoodState("Derp");
		mice5.GetComponent<unanimActor>().actorChangeMoodState("Derp");
		mice6.GetComponent<unanimActor>().actorChangeMoodState("Derp");
		
		fox.GetComponent<unanimActor>().actorChangeMoodState("Sad");
		wolf.GetComponent<unanimActor>().actorChangeMoodState("Sad");
		bear.GetComponent<unanimActor>().actorChangeMoodState("Sad");
		elk.GetComponent<unanimActor>().actorChangeMoodState("Sad");
		dog.GetComponent<unanimActor>().actorChangeMoodState("Sad");
		robot.GetComponent<unanimActor>().actorChangeMoodState("Sad");
		horse1.GetComponent<unanimActor>().actorChangeMoodState("Sad");
		horse2.GetComponent<unanimActor>().actorChangeMoodState("Sad");
	}

	void scene_6_1_roosterLanded () {
		rooster.GetComponent<unanimActor>().actorChangeMoodState("Sad");
	}

	void scene_6_2_miceBuild () {
		wagon.SetActive(false);
		mice1.GetComponent<unanimActor>().actorChangeMoodState("Derp");
		mice2.GetComponent<unanimActor>().actorChangeMoodState("Derp");
		mice3.GetComponent<unanimActor>().actorChangeMoodState("Derp");
		mice4.GetComponent<unanimActor>().actorChangeMoodState("Derp");
		mice5.GetComponent<unanimActor>().actorChangeMoodState("Derp");
		mice6.GetComponent<unanimActor>().actorChangeMoodState("Derp");
	}

	void scene_6_2_miceBuilding () {
		wagon.SetActive(true);
		drawWagon = true;
	}

	void scene_6_2_miceFinish () {
		smoke.SetActive(false);
		drawWagon = false;
		mice1.GetComponent<unanimActor>().actorChangeMoodState("Excited");
		mice2.GetComponent<unanimActor>().actorChangeMoodState("Excited");
		mice3.GetComponent<unanimActor>().actorChangeMoodState("Excited");
		mice4.GetComponent<unanimActor>().actorChangeMoodState("Excited");
		mice5.GetComponent<unanimActor>().actorChangeMoodState("Excited");
		mice6.GetComponent<unanimActor>().actorChangeMoodState("Excited");
	}

	void scene_6_3_miceWantGo () {
		mice2.GetComponent<unanimActor>().actorChangeMoodState("Idle");
		mice3.GetComponent<unanimActor>().actorChangeMoodState("Idle");
		mice4.GetComponent<unanimActor>().actorChangeMoodState("Idle");
		mice5.GetComponent<unanimActor>().actorChangeMoodState("Idle");
		mice6.GetComponent<unanimActor>().actorChangeMoodState("Idle");

		mice1.GetComponent<unanimActor>().actorChangeMoodState("Talking");
		drawWagon = false;
		drawCanWeCome = true;
	}

	void scene_6_3_miceStopTalking () {
		mice1.GetComponent<unanimActor>().actorChangeMoodState("None");
		rooster.SetActive(false);
		drawCanWeCome = false;
		drawWagon = false;
	}

	void scene_6_4_roosterOkay () {
		roosterAnim.GetComponent<unanimActor>().actorChangeMoodState("Talking");
		drawCanWeCome = false;
		drawOk = true;
	}

	void scene_6_4_roosterStop () {
		roosterAnim.GetComponent<unanimActor>().actorChangeMoodState("None");
		drawOk = false;
		drawCanWeCome = false;
	}

	void scene_6_5_animalsOnBoard () {
		drawOk = false;
		drawCanWeCome = false;
		drawWagon = false;
		wagon.SetActive(true);
		mice1.GetComponent<unanimActor>().actorChangeMoodState("Moving");
		mice2.GetComponent<unanimActor>().actorChangeMoodState("Moving");
		mice3.GetComponent<unanimActor>().actorChangeMoodState("Moving");
		mice4.GetComponent<unanimActor>().actorChangeMoodState("Moving");
		mice5.GetComponent<unanimActor>().actorChangeMoodState("Moving");
		mice6.GetComponent<unanimActor>().actorChangeMoodState("Moving");

		fox.GetComponent<unanimActor>().actorChangeMoodState("Moving");
		wolf.GetComponent<unanimActor>().actorChangeMoodState("Moving");
		bear.GetComponent<unanimActor>().actorChangeMoodState("Moving");
		elk.GetComponent<unanimActor>().actorChangeMoodState("Moving");
		dog.GetComponent<unanimActor>().actorChangeMoodState("Moving");
		robot.GetComponent<unanimActor>().actorChangeMoodState("Moving");
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
		drawCanWeCome = drawOk = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (drawWagon)
			guiScript.drawWagon = true;
		else
			guiScript.drawWagon = false;

		if (drawCanWeCome)
			guiScript.drawCanWeCome = true;
		else
			guiScript.drawCanWeCome = false;

		if (drawOk)
			guiScript.drawOkayRooster = true;
		else
			guiScript.drawOkayRooster = false;

		if (drawWagon || drawCanWeCome || drawOk)
			guiScript.enabled = true;
		else
			guiScript.enabled = false;
	}
}
