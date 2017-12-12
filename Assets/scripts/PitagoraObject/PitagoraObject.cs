using System;
using UnityEngine;

public class PitagoraObject : MonoBehaviour {

	public Quaternion rotation;

	Vector3 prevPos;

	bool isHold = false;
	public bool IsHold {
		get { return isHold; }
		set {
			if(!isHold && value) {
				OnObjectHold();
			} else if(isHold && !value) {
				OnObjectRelease();
			}

			isHold = value;
		}
	}


	void Start() {

	}

	void Update() {
		if(this.IsHold) {
			Vector3 screenPos = Input.mousePosition;
			Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
			worldPos.z = 0;
			transform.position = worldPos;
		}
	}

	void OnObjectHold() {
		prevPos = this.transform.localPosition;
	}

	void OnObjectRelease() {
		// if (IsTrashed()) {
	 //        StageManager.RemoveObject(prevPos);
	 //        Destroy(gameObject);
	 //        return;
  //     	}

  //     	Vector3 glidPos = GetFitGlidPos();
  //     	var result = StageManager.SetObject(glidPos);

		// if (result) {
	 //        StageManager.RemoveObject(prevPos);
	 //        transform.position = glidPos;
	 //        prevPos = glidPos;
  //     	} else {
  //     		this.transform.localPosition = prevPos;
  //     		this.transform.rotation = prevRotation;
  //     	}
	}

	public virtual void StartSimulation() {}
	public virtual void EndSimulation() {}
}