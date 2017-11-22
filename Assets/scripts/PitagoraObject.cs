using UnityEngine;

public class PitagoraObject : MonoBehaviour
{
  void OnMouseDrag()
  {
    Vector3 screenPos = Input.mousePosition;
    Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
    worldPos.z = 0;
    transform.position = worldPos;
  }
}
