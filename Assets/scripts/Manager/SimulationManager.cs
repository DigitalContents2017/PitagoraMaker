using UnityEngine;

public class SimulationManager : MonoBehaviour {
	
	public bool isSimulating = false;

	static SimulationButton simulationButton;
	static GameObject pitagoraObjects;
	static Object ballObject;

	void Start() {
		simulationButton = GameObject.Find("SimulationButton").GetComponent<SimulationButton>();
		pitagoraObjects = GameObject.Find("PitagoraObjects");
	}

	public void Begin() {
		Debug.Log("SimulationManager:Begin()");
		isSimulating = true;
		
		var childTransform = pitagoraObjects.GetComponentsInChildren<PitagoraObject>();
		foreach (var child in childTransform)
		{
			child.StartSimulation();
		}
	}

	public void End() {
		Debug.Log("SimulationManager:End()");
		isSimulating = false;

		Destroy(ballObject);

		var childTransform = pitagoraObjects.GetComponentsInChildren<PitagoraObject>();
		foreach (var child in childTransform)
		{
			child.EndSimulation();
		}
	}
}
