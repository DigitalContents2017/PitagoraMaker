using System;
using UnityEngine;

class Manager : MonoBehaviour
{
	public static StageManager stageManager;
	public static SimulationManager simulationManager;

	void Awake() {
		stageManager = this.transform.Find("StageManager").GetComponent<StageManager>();
		simulationManager = this.transform.Find("SimulationManager").GetComponent<SimulationManager>();
	}
}