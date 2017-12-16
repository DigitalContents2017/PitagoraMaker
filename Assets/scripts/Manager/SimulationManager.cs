using UnityEngine;

public class SimulationManager : MonoBehaviour {
	
	public bool IsSimulating = false;

	static SimulationButton simulationButton;
	static GameObject pitagoraObjects;
	static BgmManager bgmManager;
	static Object ballObject;
	static GameObject topPanel;
	static GameObject trash;

	void Start() {
		simulationButton = GameObject.Find("SimulationButton").GetComponent<SimulationButton>();
		bgmManager = GameObject.Find("BgmManager").GetComponent<BgmManager>();
		pitagoraObjects = GameObject.Find("PitagoraObjects");
		topPanel = GameObject.Find("TopPanel");
		trash = GameObject.Find("Trash");
	}

	public void Begin() {
		Debug.Log("SimulationManager:Begin()");
		IsSimulating = true;
		topPanel.SetActive(false);
		trash.SetActive(false);

		var childTransform = pitagoraObjects.GetComponentsInChildren<PitagoraObject>();
		foreach (var child in childTransform) {
			child.StartSimulation();
		}
		bgmManager.StartSimulation();
	}

	public void End() {
		Debug.Log("SimulationManager:End()");
		IsSimulating = false;

		Destroy(ballObject);
		simulationButton.IsSimulation = false; 
		topPanel.SetActive(true);
		trash.SetActive(true);

		var childTransform = pitagoraObjects.GetComponentsInChildren<PitagoraObject>();
		foreach (var child in childTransform) {
			child.EndSimulation();
		}
		bgmManager.EndSimulation();
	}
}
