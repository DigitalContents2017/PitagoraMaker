using System;
using UnityEngine;

class Goal : PitagoraObject {
	Canvas goalScreen;
	bool isSimulating = false;

	void Start() {
		StageManager.SetObject(transform.position);
		goalScreen = GameObject.Find("GoalScreen").GetComponent<Canvas>();
	}

	void OnCollisionEnter2D(Collision2D collision){
		if (isSimulating) {
			goalScreen.enabled = true;
		}
	}

	public override void StartSimulation() {
		isSimulating = true;
	}

	public override void EndSimulation() {
		isSimulating = false;
	}
}