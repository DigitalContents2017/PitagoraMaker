using UnityEngine;
using UnityEngine.EventSystems;

public class PitagoraObjectButton : MonoBehaviour, IPointerDownHandler
{
  public GameObject PitagoraObject;
  public float rotate;

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
    Quaternion quatarnion = Quaternion.Euler(0, 0, rotate);
    GameObject block = Manager.stageManager.PitagoraInstantiate(PitagoraObject, this.transform.position, quatarnion);
    block.GetComponent<Block>().isButton = true;
  }
}
