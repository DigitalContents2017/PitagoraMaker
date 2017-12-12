using System;
using UnityEngine;

public class PitagoraObject : MonoBehaviour {

	public Quaternion rotation;
	public bool IsStatic = false;

	protected Vector3 prevPos;

	bool isHold = false;
	public bool IsHold {
		get { return isHold; }
		set {
			if(!IsStatic) {
				if(!isHold && value) {
					OnObjectHold();
				} else if(isHold && !value) {
					OnObjectRelease();
				}

				isHold = value;
			} else {
				// StaticオブジェクトならHoldできない
				isHold = false;
			}
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

	protected virtual void OnObjectHold() {
		prevPos = this.transform.localPosition;
	}

	protected virtual void OnObjectRelease() {

	}

	public virtual void StartSimulation() {}
	public virtual void EndSimulation() {}
}