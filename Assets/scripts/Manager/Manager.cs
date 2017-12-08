using System;
using UnityEngine;

class Manager : MonoBehaviour
{
	public static StageManager stageManager;

	void Start() {
		stageManager = this.transform.Find("StageManager").GetComponent<StageManager>();
	}
}