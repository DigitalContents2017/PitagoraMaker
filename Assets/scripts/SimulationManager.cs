using UnityEngine;

public class SimulationManager : MonoBehaviour {
  static bool isSimulating = false;
  static SimulationButton simulationButton;

  void Start()
  {
    simulationButton = GameObject.Find("SimulationButton").GetComponent<SimulationButton>();
  }

  public static void SwitchSimulation() {
    if(isSimulating) {
      EndSimulation();
    } else {
      StartSimulation();
    }
  }

  static void StartSimulation()
  {
    Debug.Log("start");
    isSimulating = true;
    simulationButton.StartSimulation();
  }

  static void EndSimulation()
  {
    Debug.Log("end");
    isSimulating = false;
    simulationButton.EndSimulation();
  }
}
