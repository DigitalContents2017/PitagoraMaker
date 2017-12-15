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
		simulation = Manager.simulationManager;
		bgmManager = GameObject.Find("BgmManager").GetComponent<BgmManager>();
	}

	void OnCollisionEnter2D(Collision2D collision){
		PitagoraObject pObject = collision.gameObject.GetComponent<PitagoraObject>();
		if (pObject.IsMotion && Manager.simulationManager.isSimulating && !isGoal) {
			goalScreen.enabled = true;
			bgmManager.OnGoal();
			isGoal = true;
		}
	}

	public override void StartSimulation() {
		simulation.isSimulating = true;
	}

	public override void EndSimulation() {
		simulation.isSimulating = false;
		isGoal = false;
	}
}
