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
    Manager.stageManager.Instantiate(PitagoraObject, this.transform.position);
  }
}
