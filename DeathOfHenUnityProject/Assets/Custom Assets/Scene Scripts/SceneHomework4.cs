using UnityEngine;
using System.Collections;

public class SceneHomework4 : MonoBehaviour {

	// Enumerations
	private const int UNANIM_NULL = -1;
	private const int UNANIM_NONE = 0;
	private const int UNANIM_IDLE = 1;
	private const int UNANIM_EXCITED = 2;
	private const int UNANIM_SAD = 3;
	private const int UNANIM_TALKING = 4;
	private const int UNANIM_MOVING = 5;
	private const int UNANIM_DERP = 6;
	private const int UNANIM_EXCITED_MOVING = 7;

	// Public Hen Object to sample animations; the animations
	// will also be controlled for this homework assignment.
	public GameObject hen;

	// Private variables that the users do not need to really see...
	private Animator anim;
	private int lastMoodState;
	private float excitedToRun;
	
	// Use this for initialization
	void Start () {
		anim = ((unanimActor)hen.GetComponent (typeof(unanimActor))).GetComponentInChildren<Animator>();
		anim.SetInteger("Mood State", UNANIM_NONE);
		excitedToRun = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Q)) {
			anim.SetBool ( "Derp", !(anim.GetBool("Derp")) );
			if (anim.GetBool("Derp")) {
				lastMoodState = anim.GetInteger("Mood State");
				anim.SetInteger ("Mood State", UNANIM_NULL);
			} else {
				anim.SetInteger ("Mood State", lastMoodState);
			}
		}
		if (Input.GetKey (KeyCode.E))
			anim.SetTrigger ("Jump");

		if (Input.GetKey (KeyCode.F) && excitedToRun <= 1.0f) {
			anim.SetFloat ("Run Excited Threshold", excitedToRun = excitedToRun + 0.02f);
		} else if (Input.GetKey (KeyCode.G) && excitedToRun <= 1.0f) {
			anim.SetFloat ("Run Excited Threshold", excitedToRun = excitedToRun + 0.05f);
		} else if (excitedToRun != 0.0f) {
			anim.SetFloat ("Run Excited Threshold", excitedToRun = excitedToRun - 0.02f);
		}

		if (!anim.GetBool("Derp")) {
			if (Input.GetKeyDown (KeyCode.Alpha1))
				anim.SetInteger ("Mood State", UNANIM_IDLE);
			else if (Input.GetKeyDown (KeyCode.Alpha2))
				anim.SetInteger ("Mood State", UNANIM_EXCITED);
			else if (Input.GetKeyDown (KeyCode.Alpha3))
				anim.SetInteger ("Mood State", UNANIM_SAD);
			else if (Input.GetKeyDown (KeyCode.Alpha4))
				anim.SetInteger ("Mood State", UNANIM_TALKING);
			else if (Input.GetKeyDown (KeyCode.Alpha5))
				anim.SetInteger ("Mood State", UNANIM_MOVING);
			else if (Input.GetKeyDown (KeyCode.Alpha6))
				anim.SetInteger ("Mood State", UNANIM_DERP);
			else if (Input.GetKeyDown (KeyCode.Alpha7))
				anim.SetInteger ("Mood State", UNANIM_EXCITED_MOVING);
			else if (Input.GetKeyDown (KeyCode.Alpha0))
				anim.SetInteger ("Mood State", UNANIM_NONE);
		}
	}
}
