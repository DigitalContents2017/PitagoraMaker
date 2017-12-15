using System;
using System.Collections;
using UnityEngine;

class Goal : PitagoraObject {
	Canvas goalScreen;
	SimulationManager simulation;

	void Start() {
		StageManager.SetObject(this.transform.position);
		goalScreen = GameObject.Find("GoalScreen").GetComponent<Canvas>();
		simulation = Manager.simulationManager;
	}

	void OnCollisionEnter2D(Collision2D collision){
		if (Manager.simulationManager.isSimulating) {
			goalScreen.enabled = true;
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
	}
}