using UnityEngine;
using System.Collections;

public class unanimActor : MonoBehaviour {

	// Enumeration of Mood States
	const int UNANIM_NONE = 0;
	const int UNANIM_IDLE = 1;
	const int UNANIM_EXCITED = 2;
	const int UNANIM_SAD = 3;
	const int UNANIM_TALKING = 4;
	const int UNANIM_MOVING = 5;
	const int UNANIM_DERP = 6;
	const int UNANIM_EXCITED_MOVING = 7;
	const int UNANIM_ANGRY = 8;

	// Animator Controller object
	Animator animator;
	
	void Start () {
		animator = GetComponentInChildren<Animator>();
		animator.SetFloat ("Run Excited Threshold", 0.0f);
		animator.SetInteger ("Mood State", UNANIM_NONE);
	}

	// Function for other classes to use to change Mood State
	public void actorChangeMoodState (string input) {
		animator.SetFloat ("Run Excited Threshold", 0.0f);
		switch (input) {
		case "Idle":
			animator.SetInteger ("Mood State", UNANIM_IDLE);
			break;
		case "Excited":
			animator.SetInteger ("Mood State", UNANIM_EXCITED);
			break;
		case "Sad":
			animator.SetInteger ("Mood State", UNANIM_SAD);
			break;
		case "Talking":
			animator.SetInteger ("Mood State", UNANIM_TALKING);
			break;
		case "Moving":
			animator.SetInteger ("Mood State", UNANIM_MOVING);
			break;
		case "Derp":
			animator.SetInteger ("Mood State", UNANIM_DERP);
			break;
		case "Excited and Moving":
			animator.SetInteger ("Mood State", UNANIM_EXCITED_MOVING);
			animator.SetFloat ("Run Excited Threshold", 0.2f);
			break;
		case "Angry":
			animator.SetInteger ("Mood State", UNANIM_ANGRY);
			break;
		default:
			animator.SetInteger ("Mood State", UNANIM_NONE);
			break;
		}
	}
}
