using System;
using UnityEngine;

class Manager : MonoBehaviour
{
	public static StageManager stageManager;

	void Awake() {
		stageManager = this.transform.Find("StageManager").GetComponent<StageManager>();
	}
}