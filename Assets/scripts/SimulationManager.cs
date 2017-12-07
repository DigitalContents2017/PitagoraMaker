using UnityEngine;

public class SimulationManager : MonoBehaviour {
  static bool isSimulating = false;
  static SimulationButton simulationButton;
  static GameObject ballPrefab;
  static Object ballObject;

  void Start()
  {
    simulationButton = GameObject.Find("SimulationButton").GetComponent<SimulationButton>();
    ballPrefab = (GameObject)Resources.Load("Prefabs/Ball");
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
    Vector2 startPos = new Vector2(-15, 5);
    isSimulating = true;
    simulationButton.StartSimulation();
    ballObject = Instantiate(ballPrefab, startPos, Quaternion.identity);
  }

  static void EndSimulation()
  {
    Debug.Log("end");
    isSimulating = false;
    simulationButton.EndSimulation();
    Destroy(ballObject);
  }
}
