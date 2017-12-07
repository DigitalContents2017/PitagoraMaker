using UnityEngine;

public class SimulationManager : MonoBehaviour {
  static bool isSimulating = false;

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
  }

  static void EndSimulation()
  {
    Debug.Log("end");
    isSimulating = false;
  }
}
