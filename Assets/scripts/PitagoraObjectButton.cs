using UnityEngine;
using UnityEngine.EventSystems;

public class PitagoraObjectButton : MonoBehaviour, IPointerDownHandler {
	public GameObject PitagoraObject;
	public float rotate;

	public void OnPointerDown (PointerEventData eventData) {
		CreateObject();
	}

	void CreateObject() {
		Quaternion quatarnion = Quaternion.Euler(0, 0, rotate);
		var pitagoraObject = Manager.stageManager.PitagoraInstantiate(PitagoraObject, this.transform.position, quatarnion);
	}
}
