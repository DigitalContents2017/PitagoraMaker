using UnityEngine;
using UnityEngine.UI;

public class SimulationButton : MonoBehaviour {
	public Sprite StartSprite;
	public Sprite EndSprite;
	Image image;

	void Start()
	{
		image = GetComponent<Image>();
	}

	public void OnClick()
	{
		SimulationManager.SwitchSimulation();
	}

	public void StartSimulation()
	{
		image.sprite = EndSprite;
	}

	public void EndSimulation()
	{
		image.sprite = StartSprite;
	}
}
