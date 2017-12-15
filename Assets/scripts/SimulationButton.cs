using UnityEngine;
using UnityEngine.UI;

public class SimulationButton : MonoBehaviour {
	public Sprite StartSprite;
	public Sprite EndSprite;
	Image image;

	bool isSimulation = false;

	void Start() {
		image = this.GetComponent<Image>();
		image.sprite = StartSprite;
	}

	public void OnClick() {
		if(!isSimulation) {
			Manager.simulationManager.Begin();
			image.sprite = EndSprite;
		} else {
			Manager.simulationManager.End();
			image.sprite = StartSprite;
		}

		isSimulation = !isSimulation;
	}
}
