using System;
using UnityEngine;

public class PitagoraObject : MonoBehaviour {

	public Quaternion rotation;
	public bool IsStatic = false;
	protected bool isSimulating = false;

	protected Vector3 prevPos;

	bool isHold = false;
	public bool IsHold {
		get { return isHold; }
		set {
			if(!IsStatic && !isSimulating) {
				if(!isHold && value) {
					OnObjectHold();
				} else if(isHold && !value) {
					OnObjectRelease();
				}

				isHold = value;
			} else {
				// Staticオブジェクトまたはシュミレーション中ならHoldできない
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
		rotation = this.transform.rotation;
	}

	protected virtual void OnObjectRelease() {

	}

	public virtual void StartSimulation() {}
	public virtual void EndSimulation() {}
}