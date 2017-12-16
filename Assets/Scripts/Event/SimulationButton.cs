using UnityEngine;
using UnityEngine.UI;

public class SimulationButton : MonoBehaviour {
	public Sprite StartSprite;
	public Sprite EndSprite;
	Image image;

	bool isSimulation = false;
	public bool IsSimulation {
		get { return isSimulation; }
		set {
			if(value) image.sprite = EndSprite;
			else image.sprite = StartSprite;
			isSimulation = value;
		}
	}

	void Start() {
		image = this.GetComponent<Image>();
		image.sprite = StartSprite;
	}

	public void OnClick() {
		this.IsSimulation = !isSimulation;

		if(this.IsSimulation) {
			Manager.simulationManager.Begin();
		} else {
			Manager.simulationManager.End();	
		}
	}
}
