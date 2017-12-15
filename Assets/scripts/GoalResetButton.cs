using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalResetButton : MonoBehaviour {
	Canvas goalScreen;
	GameObject pitagoraObjects;

	void Start()
	{
		goalScreen = GameObject.Find("GoalScreen").GetComponent<Canvas>();
		pitagoraObjects = GameObject.Find("PitagoraObjects");
	}

	public void OnClick()
	{
		goalScreen.enabled = false;
		Manager.simulationManager.End();

		var childTransform = pitagoraObjects.GetComponentsInChildren<PitagoraObject>();
		foreach (var child in childTransform)
		{
			child.RemoveObject();
		}
	}
}
