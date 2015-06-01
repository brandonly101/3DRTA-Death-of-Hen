using UnityEngine;
using System.Collections;

public class globalScript : MonoBehaviour {

	// Public variables to interface with Inspector and other scripts
	public int activeScene;
	public GameObject[] objectScenes;
	public Terrain terrain;
	
	// Private variables and functions
	int sceneCurrent;
	bool sceneDone;
	LightmapData[] lightmapData;

	void sceneMakeInactive () {
		foreach (GameObject scene in objectScenes) {
			scene.SetActive (false);
		}
	}

	// Public Function Implementations
	public void toggleSceneDone () {
		sceneDone = true;
	}

	public void loadLightmap () {
		lightmapData = new LightmapData[10];
		for (int i = 0; i < 2; i++) {
			lightmapData[i] = new LightmapData();
			lightmapData[i].lightmapFar = Resources.Load("Lightmaps/LightmapFar-" + i.ToString(), typeof(Texture2D)) as Texture2D;
			lightmapData[i].lightmapNear = Resources.Load("Lightmaps/LightmapNear-" + i.ToString(), typeof(Texture2D)) as Texture2D;
		}
		LightmapSettings.lightmaps = lightmapData;
	}

	void resetEverything() {
		sceneDone = false;
		sceneMakeInactive ();
		sceneCurrent = activeScene;
	}

	////////////////////////////////////////////////
	// Rendering functions (Start () and Update ())
	////////////////////////////////////////////////

	void Start () {
		sceneDone = false;
		sceneMakeInactive ();
		sceneCurrent = activeScene;
		objectScenes[sceneCurrent].SetActive (true);
		terrain.lightmapIndex = -1;
	}
		
	void Update () {
		// If the current scene is done, update the sceneCurrent
		// iterator and make the next scene active!
		if (sceneDone) {
			sceneDone = false;
			sceneMakeInactive();
			sceneCurrent++;
			objectScenes[sceneCurrent].SetActive (true);
		}
	}
}
