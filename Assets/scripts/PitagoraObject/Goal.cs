using System;
using System.Collections;
using UnityEngine;

class Goal : PitagoraObject {
	Canvas goalScreen;
	BgmManager bgmManager;
	bool isGoal = false;

	void Start() {
		StageManager.SetObject(transform.position);
		goalScreen = GameObject.Find("GoalScreen").GetComponent<Canvas>();
		bgmManager = GameObject.Find("BgmManager").GetComponent<BgmManager>();
	}

	void OnCollisionEnter2D(Collision2D collision){
		if (isSimulating && !isGoal) {
			goalScreen.enabled = true;
			bgmManager.OnGoal();
			isGoal = true;
		}
	}

	public override void StartSimulation() {
		// 最初から隣接されているものは無視する。
		StartCoroutine(DelayMethod(1, () => isSimulating = true));
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
		isSimulating = false;
		isGoal = false;
	}
}
