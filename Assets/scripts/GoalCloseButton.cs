using UnityEngine;
using UnityEngine.UI;

public class GoalCloseButton : MonoBehaviour
{
	Canvas goalScreen;

	void Start()
	{
		goalScreen = GameObject.Find("GoalScreen").GetComponent<Canvas>();
	}

	public void OnClick()
	{
		goalScreen.enabled = false;
		Manager.simulationManager.End();
		GameObject.Find("SimulationButton").GetComponent<SimulationButton>().IsSimulation = false;
	}
}
