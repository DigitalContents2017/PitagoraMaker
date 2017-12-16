using System;
using System.Collections;
using UnityEngine;

class Goal : PitagoraObject {
	Canvas goalScreen;
	SimulationManager simulation;
	BgmManager bgmManager;
	bool isGoal = false;

	void Start() {
		StageManager.SetObject(this.transform.position);
		goalScreen = GameObject.Find("GoalScreen").GetComponent<Canvas>();
		bgmManager = GameObject.Find("BgmManager").GetComponent<BgmManager>();
		simulation = Manager.simulationManager;
	}

	void OnCollisionEnter2D(Collision2D collision){
		var pObject = collision.gameObject.GetComponent<PitagoraObject>();

		if (pObject.IsMotion && simulation.IsSimulating && !isGoal) {
			goalScreen.enabled = true;
			bgmManager.OnGoal();
			isGoal = true;
		}
	}

	public override void StartSimulation() {
		simulation.IsSimulating = true;
	}

	public override void EndSimulation() {
		simulation.IsSimulating = false;
		isGoal = false;
	}
}
