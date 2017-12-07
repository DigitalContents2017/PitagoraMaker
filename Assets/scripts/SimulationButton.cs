using UnityEngine;
using UnityEngine.UI;

public class SimulationButton : MonoBehaviour {
  Text targetText;

  void Start()
  {
    targetText = GameObject.Find("SimulationButton/Text").GetComponent<Text>();
  }

  public void OnClick()
  {
    SimulationManager.SwitchSimulation();
  }

  public void StartSimulation()
  {
    targetText.text = "Finish";
  }

  public void EndSimulation()
  {
    targetText.text = "Start";
  }
}
