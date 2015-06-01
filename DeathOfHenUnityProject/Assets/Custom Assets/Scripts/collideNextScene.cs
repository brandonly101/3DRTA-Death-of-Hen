using UnityEngine;
using System.Collections;

public class collideNextScene : MonoBehaviour {

	GameObject globalObject;
	Transform target;

	// Use this for initialization
	void Start () {
		// Initialize Global Object and GUI Script in Global Object
		globalObject = GameObject.FindGameObjectWithTag("Global");
		target = GameObject.FindGameObjectWithTag("Player Wagon").transform;
	}

	void Update () {
		if (Vector3.Distance(transform.position,target.position) <= 10.0f) {
			globalObject.GetComponent<globalScript>().toggleSceneDone();
		}
	}
}
