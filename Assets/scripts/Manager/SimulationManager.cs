using UnityEngine;

public class SimulationManager : MonoBehaviour {
	
	public bool isSimulating = false;

	static SimulationButton simulationButton;
	static GameObject pitagoraObjects;
	static Object ballObject;

	void Start()
	{
		simulationButton = GameObject.Find("SimulationButton").GetComponent<SimulationButton>();
		pitagoraObjects = GameObject.Find("PitagoraObjects");
	}

	public void SwitchSimulation() {
		if(isSimulating) {
			  EndSimulation();
		} else {
			  StartSimulation();
		}
	}

	public void StartSimulation()
	{
		Debug.Log("SimulationManager:StartSimulation()");
		isSimulating = true;
		simulationButton.StartSimulation();

		var childTransform = pitagoraObjects.GetComponentsInChildren<PitagoraObject>();
		foreach (var child in childTransform)
		{
			child.StartSimulation();
		}
	}

	public void EndSimulation()
	{
		Debug.Log("SimulationManager:EndSimulation()");
		isSimulating = false;
		simulationButton.EndSimulation();
		Destroy(ballObject);

		var childTransform = pitagoraObjects.GetComponentsInChildren<PitagoraObject>();
		foreach (var child in childTransform)
		{
			child.EndSimulation();
		}
	}
}
