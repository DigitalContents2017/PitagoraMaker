using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmManager : MonoBehaviour {
	public AudioClip simulating;
	public AudioClip goal;
	private AudioSource audioSource;

	void Start () {
		audioSource = gameObject.GetComponent<AudioSource>();
	}

	public void StartSimulation() {
		audioSource.clip = simulating;
		audioSource.Play();
	}

	public void EndSimulation() {
		audioSource.Stop();
	}

	public void OnGoal() {
		audioSource.clip = goal;
		audioSource.Play();
	}
}
