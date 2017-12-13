﻿using UnityEngine;
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
		SimulationManager.EndSimulation();
	}
}
