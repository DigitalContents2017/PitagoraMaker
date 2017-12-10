using UnityEngine;

public class SimulationManager : MonoBehaviour {
  static bool isSimulating = false;
  static SimulationButton simulationButton;
  static GameObject ballPrefab;
  static GameObject pitagoraObjects;
  static Object ballObject;

  void Start()
  {
    simulationButton = GameObject.Find("SimulationButton").GetComponent<SimulationButton>();
    ballPrefab = (GameObject)Resources.Load("Prefabs/Ball");
    pitagoraObjects = GameObject.Find("PitagoraObjects");
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
    ballObject = Manager.stageManager.PitagoraInstantiate(ballPrefab, startPos);

    var childTransform = pitagoraObjects.GetComponentsInChildren<PitagoraObject>();
    foreach (var child in childTransform)
    {
      child.StartSimulation();
    }
  }

  static void EndSimulation()
  {
    Debug.Log("end");
    isSimulating = false;
    simulationButton.EndSimulation();
    Destroy(ballObject);

    var childTransform = pitagoraObjects.GetComponentsInChildren<PitagoraObject>();
    foreach (var child in childTransform)
    {
      child.EndSimulation();
    }
  }
}
