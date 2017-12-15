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
		if (Manager.simulationManager.isSimulating && !isGoal) {
			goalScreen.enabled = true;
			bgmManager.OnGoal();
			isGoal = true;

			GameObject.Find("SimulationButton").GetComponent<SimulationButton>().IsSimulation = false;
		}
	}

	public override void StartSimulation() {
		// 最初から隣接されているものは無視する。
		StartCoroutine(DelayMethod(1, () => simulation.isSimulating = true));
	}

	IEnumerator DelayMethod(int delayFrameCount, Action action)
	{
		for (var i = 0; i < delayFrameCount; i++)
		{
			yield return null;
		}
		action();
	}

	public override void EndSimulation() {
		simulation.isSimulating = false;
		isGoal = false;
	}
}
