using UnityEngine;

public class SimulationButton : MonoBehaviour {
  public void OnClick()
  {
    SimulationManager.SwitchSimulation();
  }
}
