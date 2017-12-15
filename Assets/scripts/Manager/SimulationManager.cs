using UnityEngine;

public class SimulationManager : MonoBehaviour {
	static bool isSimulating = false;
	static SimulationButton simulationButton;
	static GameObject pitagoraObjects;
	static BgmManager bgmManager;
	static Object ballObject;
	static GameObject topPanel;
	static GameObject trash;

	void Start()
	{
		simulationButton = GameObject.Find("SimulationButton").GetComponent<SimulationButton>();
		bgmManager = GameObject.Find("BgmManager").GetComponent<BgmManager>();
		pitagoraObjects = GameObject.Find("PitagoraObjects");
		topPanel = GameObject.Find("TopPanel");
		trash = GameObject.Find("Trash");
	}

	public static void SwitchSimulation() {
		if(isSimulating) {
			  EndSimulation();
		} else {
			  StartSimulation();
		}
	}

	public static void StartSimulation()
	{
		Debug.Log("start");
		isSimulating = true;
		simulationButton.StartSimulation();
		topPanel.SetActive(false);
		trash.SetActive(false);

		var childTransform = pitagoraObjects.GetComponentsInChildren<PitagoraObject>();
		foreach (var child in childTransform)
		{
			child.StartSimulation();
		}
		bgmManager.StartSimulation();
	}

	public static void EndSimulation()
	{
		Debug.Log("end");
		isSimulating = false;
		simulationButton.EndSimulation();
		Destroy(ballObject);
		topPanel.SetActive(true);
		trash.SetActive(true);

		var childTransform = pitagoraObjects.GetComponentsInChildren<PitagoraObject>();
		foreach (var child in childTransform)
		{
			child.EndSimulation();
		}
		bgmManager.EndSimulation();
	}
}
