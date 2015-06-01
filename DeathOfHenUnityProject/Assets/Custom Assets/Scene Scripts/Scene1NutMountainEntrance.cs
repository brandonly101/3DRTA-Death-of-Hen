using UnityEngine;
using System.Collections;

public class Scene1NutMountainEntrance : MonoBehaviour {
	
	public GameObject rooster;
	public GameObject hen;
	public GameObject waypoint;
	public Texture2D image;
	
	[HideInInspector]
	private GameObject globalObject;
	[HideInInspector]
	private bool nutMountainSign;
	

	////////////////////////////////////////////////
	// Animation Functions
	////////////////////////////////////////////////

	void sceneShowNutMountain () {
		LightmapSettings.lightmaps = new LightmapData[]{};
		nutMountainSign = true;
		rooster.GetComponent<unanimActor>().actorChangeMoodState("Idle");
		hen.GetComponent<unanimActor>().actorChangeMoodState("Excited");
	}

	void sceneRoosterHenSeeMountain () {
		nutMountainSign = false;
	}

	void sceneRoosterHenGoUpMountain () {
		nutMountainSign = false;
	}

	void sceneDone () {
		globalObject.GetComponent<globalScript>().toggleSceneDone();
	}

	////////////////////////////////////////////////
	// Rendering functions (Start () and Update ())
	////////////////////////////////////////////////

	void Start () {
		globalObject = GameObject.FindGameObjectWithTag("Global");
		nutMountainSign = GameObject.Find("NutMountainTexture");
		nutMountainSign = false;

		LightmapSettings.lightmaps = new LightmapData[]{};
	}

	void OnGUI () {
		if (nutMountainSign) {
			GUI.Label (
				new Rect (
					(float)(Screen.width * 0.01), 
			    	(float)(Screen.height * 0.15),
			        (float)(Screen.width * 0.7),
			        (float)(Screen.height * 0.2)
			    ),
			image);
		}
	}
}
