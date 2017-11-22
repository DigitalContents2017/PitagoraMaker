using UnityEngine;
using UnityEngine.EventSystems;

public class PitagoraObjectButton : MonoBehaviour, IPointerDownHandler
{
  public GameObject PitagoraObject;

  void Start()
  {
    CreateObject();
  }

  public void OnPointerDown (PointerEventData eventData)
  {
    CreateObject();
  }

  void CreateObject()
  {
    Vector3 position = transform.position;
    Instantiate(PitagoraObject, position, Quaternion.identity);
  }
}
