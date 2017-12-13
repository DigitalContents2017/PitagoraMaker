using System;
using System.Collections;
using UnityEngine;

class Goal : PitagoraObject {
	Canvas goalScreen;

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
	}
}