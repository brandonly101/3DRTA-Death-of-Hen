using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class collideTrigger : MonoBehaviour {
	public AudioClip impact;
	void OnCollisionEnter() {
		audio.PlayOneShot(impact);
	}
}
