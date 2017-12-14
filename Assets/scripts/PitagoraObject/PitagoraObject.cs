using System;
using UnityEngine;

public class PitagoraObject : MonoBehaviour {

	public Quaternion rotation;
	public bool IsStatic = false;
	protected bool isSimulating = false;

	protected Vector3 prevPos;

	bool _isTouch = false;

	bool isHold = false;
	public bool IsHold {
		get { return isHold; }
		set {
			if(!IsStatic && !isSimulating) {
				if(!isHold && value) {
					OnObjectPressed();
				} else if(isHold && !value) {
					OnObjectReleased();
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
		UpdateTouch();

		if(this.IsHold) {
			Vector3 screenPos = Input.mousePosition;
			Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
			worldPos.z = 0;
			transform.position = worldPos;
		}
	}

	protected virtual void OnObjectPressed() {
		prevPos = this.transform.localPosition;
		rotation = this.transform.rotation;
	}

	protected virtual void OnObjectReleased() {

	}

	void OnMouseDown() {
		this.IsHold = true;
	}

	void OnMouseDrag() {

	}

	void OnMouseUp() {
		this.IsHold = false;
	}

	void OnTouchDown() {
		this.IsHold = true;
	}

	void OnTouchUp() {
		this.IsHold = false;
	}

	void UpdateTouch() {
		var isTouch = false;

        // タッチされているとき
        if(0 < Input.touchCount){
            // タッチされている指の数だけ処理
            for(int i = 0; i < Input.touchCount; i++){
                // タッチ情報をコピー
                Touch t = Input.GetTouch(i);
                // タッチしたときかどうか
                if(t.phase == TouchPhase.Began ){
                    //タッチした位置からRayを飛ばす
                    Ray ray = Camera.main.ScreenPointToRay(t.position);
                    RaycastHit hit = new RaycastHit();
                    if (Physics.Raycast(ray, out hit)){
                        //Rayを飛ばしてあたったオブジェクトが自分自身だったら
                        if (hit.collider.gameObject == this.gameObject){
                            isTouch = true;
                            break;
                        }
                    }
                }
            }
        }

        if(isTouch != _isTouch) {
        	if(isTouch) OnTouchDown();
        	else OnTouchUp();
        }

        _isTouch = isTouch;
    }

	public virtual void StartSimulation() {}
	public virtual void EndSimulation() {}
}