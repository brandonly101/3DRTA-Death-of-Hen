using UnityEngine;
using System.Collections;

public class rockAI : MonoBehaviour {

	public Transform target;

	const int BEHAVIOR_IDLE = 0;
	const int BEHAVIOR_ALERT = 1;
	const int BEHAVIOR_ACTIVE = 2;

	const int ACTION_IDLE = 0;
	const int ACTION_UPDOWN = 1;
	const int ACTION_LEFTRIGHT = 2;
	const int ACTION_ROTATE = 3;

	public float detectionRange;
	public float alertTimeRange;
	public float moveSpeed;
	public float moveRange;

	public unanimActor animRock;
	int behaviorStateCurrent;
	int behaviorStateNew;
	float timeAlert;
	float distance;
	Vector3 localPos;
	Quaternion localRot;

	bool actionUpDown;
	bool actionLeftRight;
	bool actionRotate;

	bool up, down, left, right;

	public void disableAI () {
		behaviorStateCurrent = -1;
	}

	public void enableAI () {
		behaviorStateCurrent = 0;
	}

	void doAlert () {
		animRock.actorChangeMoodState("Angry");
		print ("Rock Alerted!");
	}
	
	void doAction () {
		animRock.actorChangeMoodState("None");
		float chance = Random.value;
		if (0.0f <= chance && chance < 0.25f) {
			animRock.actorChangeMoodState("Idle");
		} else if (0.25f <= chance && chance < 0.50f) {
			actionUpDown = true;
			print ("Rock Going Up and Down!");
		} else if (0.50f <= chance && chance < 0.75f) {
			actionLeftRight = true;
			print ("Rock Going Left and Right!");
		} else if (0.75f <= chance && chance <= 1.00f) {
			actionRotate = true;
			print ("Rock Rotating!");
		}
	}

	void doRevert () {
		animRock.actorChangeMoodState("Idle");
		transform.localPosition = localPos;
		transform.localRotation = localRot;
		actionUpDown = actionLeftRight = actionRotate = false;
		behaviorStateCurrent = 0;
		behaviorStateNew = 0;
		timeAlert = 0;
	}
	
	// Use this for initialization
	void Start () {
		// Initialize Global Object and GUI Script in Global Object
		target = GameObject.FindGameObjectWithTag("Player Wagon").transform;

		// Initialize needed variables
		animRock = gameObject.GetComponent<unanimActor>();

		// Initialize variables to 0
		behaviorStateCurrent = 0;
		behaviorStateNew = 0;
		timeAlert = 0.0f;
		distance = 999f;
		detectionRange = 27f;
		alertTimeRange = 1.4f;
		actionUpDown = actionLeftRight = actionRotate = up = left = false;
		down = right = true;
		localPos = transform.localPosition;
		localRot = transform.localRotation;
		moveSpeed = 15f;
		moveRange = 25f;
}

	// Update is called once per frame
	void Update () {
		distance = Vector3.Distance(localPos, target.localPosition);

		// Parse distance and prep changes in state
		if (distance < detectionRange) {
			if (behaviorStateCurrent == BEHAVIOR_IDLE) {
				behaviorStateNew = BEHAVIOR_ALERT;
			} else if (behaviorStateCurrent == BEHAVIOR_ALERT && timeAlert < alertTimeRange) {
				timeAlert += Time.deltaTime;
			} else if (behaviorStateCurrent == BEHAVIOR_ALERT && alertTimeRange <= timeAlert) {
				behaviorStateNew = BEHAVIOR_ACTIVE;
			}
		} else if (detectionRange <= distance) {
			if (behaviorStateCurrent == BEHAVIOR_ALERT && timeAlert < alertTimeRange) {
				timeAlert += Time.deltaTime;
			} else if ((behaviorStateCurrent == BEHAVIOR_ALERT && alertTimeRange <= timeAlert) ||
			           behaviorStateCurrent == BEHAVIOR_ACTIVE) {
				behaviorStateNew = BEHAVIOR_IDLE;
			}
		}

		// What happens if new and current are different...?
		if (behaviorStateCurrent == BEHAVIOR_IDLE && behaviorStateNew == BEHAVIOR_ALERT) {
			doAlert();
			behaviorStateCurrent = behaviorStateNew;
		} else if (behaviorStateCurrent == BEHAVIOR_ALERT && behaviorStateNew == BEHAVIOR_ACTIVE) {
			doAction();
			behaviorStateCurrent = behaviorStateNew;
		} else if ((behaviorStateCurrent == BEHAVIOR_ACTIVE && behaviorStateNew == BEHAVIOR_IDLE) ||
		           (behaviorStateCurrent == BEHAVIOR_ALERT && behaviorStateNew == BEHAVIOR_IDLE)) {
			doRevert();
			behaviorStateCurrent = behaviorStateNew;
		}

		// Actual actions to do
		if (actionLeftRight) {
			if (localPos.z + moveRange < transform.localPosition.z) {
				left = false;
				right = true;
			}
			if (transform.localPosition.z < localPos.z - moveRange) {
				left = true;
				right = false;
			}
			
			if (left)
				transform.localPosition = 
					new Vector3 (transform.localPosition.x,
					             transform.localPosition.y,
					             transform.localPosition.z + Time.deltaTime * moveSpeed);
			if (right)
				transform.localPosition =
					new Vector3 (transform.localPosition.x,
					             transform.localPosition.y,
					             transform.localPosition.z - Time.deltaTime * moveSpeed);
		}
		if (actionUpDown) {
			if (localPos.y + moveRange < transform.localPosition.y) {
				up = false;
				down = true;
			}
			if (transform.localPosition.y < localPos.y - moveRange) {
				up = true;
				down = false;
			}

			if (up)
				transform.localPosition = 
					new Vector3(transform.localPosition.x,
					            transform.localPosition.y + Time.deltaTime * moveSpeed,
					            transform.localPosition.z);
			if (down)
				transform.localPosition =
					new Vector3(transform.localPosition.x,
					            transform.localPosition.y - Time.deltaTime * moveSpeed,
					            transform.localPosition.z);
		}
		if (actionRotate) {
			transform.Rotate(Vector3.left * Time.deltaTime * moveSpeed * 1.69f, Space.World);
		}
	}
}
