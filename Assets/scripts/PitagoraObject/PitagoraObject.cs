using System;
using UnityEngine;

public class PitagoraObject : MonoBehaviour {

	public Quaternion rotation;

	protected Vector3 prevPos;

	bool _isTouch = false;
	int touchNo = -1;

	// 静的なオブジェクト
	public bool IsStatic = false;

	protected bool IsInstalled = false;
	
	// ゴールに影響を与えるオブジェクト
	public bool IsMotion = false;
	
	public bool IsChild = false;

	bool isHold = false;
	public bool IsHold {
		get {
			if(IsStatic) return false;
			else return isHold;
		} set {
			if(!IsStatic) {
				if(!isHold && value) {
					OnObjectPressed();
				} else if(isHold && !value) {
					OnObjectReleased();
				}

				isHold = value;
			}
		}
	}


	void Start() {
		// タッチ用
		if (Input.touchCount > 0) {
	    	// タッチされている指の数だけ処理
	    	for (int i = 0; i < Input.touchCount; i++) {
	    		var touch = Input.GetTouch(i);
	    		//タッチした位置からRayを飛ばす
	    		Vector2 worldPoint = Camera.main.ScreenToWorldPoint(touch.position);
	    		RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

	    		if (hit) {
    				//Rayを飛ばしてあたったオブジェクトが自分自身だったら
    				if (hit.collider.gameObject == this.gameObject) {
    					touchNo = touch.fingerId;
    					OnTouchDown();
    					return;
    				}
    			}
    		}
    	} else {
    		// OnMouseDown();
    	}

    	OnStart();
	}

	void Update() {
		if(!this.IsChild) UpdateTouch();

		if(this.IsHold && touchNo == -1) {
			Vector3 screenPos = Input.mousePosition;
			Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
			worldPos.z = 0;
			this.transform.position = worldPos;
		}

		if(this.IsInstalled && this.transform.localPosition.y >= 8.1f && !this.IsMotion) {
			Debug.Log("ismotion :"  + this.IsMotion);
			Destroy(this.gameObject);
		}

		OnUpdate();
	}

	protected virtual void OnObjectPressed() {
		Debug.Log("PitagoraObject:OnOnjectPressed()");

		prevPos = this.transform.localPosition;
		rotation = this.transform.rotation;

		var rigidbody = GetComponent<Rigidbody2D>();
		if(rigidbody != null) rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
	}

	protected virtual void OnObjectReleased() {
		Debug.Log("PitagoraObject:OnOnjectReleased()");
		if (this.transform.localPosition.y >= 8.1f) {
			// Destroy(gameObject);
			Debug.Log("bbb");
			return;
		}
	}
/*
	void OnMouseDown() {
		if (this.IsChild) return;

		Debug.Log("OnMouseDown");
		this.IsHold = true;
	}

	void OnMouseDrag() {
		if (this.IsChild) return;
		
		if(this.IsHold) {
			Vector3 screenPos = Input.mousePosition;
			Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
			worldPos.z = 0;
			this.transform.position = worldPos;
		}
	}

	void OnMouseUp() {
		if (this.IsChild) return;
		
		this.IsHold = false;
	}*/

	void OnTouchDown() {
    	Debug.Log("OnTouchDown");
		this.IsHold = true;
	}

	void OnTouchDrag(Vector2 worldPoint) {
		this.transform.position = worldPoint;
	}

	void OnTouchUp() {
    	Debug.Log("OnTouchUp");
    	this.IsHold = false;
	}

	void UpdateTouch() {
	    // タッチされているとき
	    if (Input.touchCount > 0) {
	    	// タッチされている指の数だけ処理
	    	for (int i = 0; i < Input.touchCount; i++) {
	    		var touch = Input.GetTouch(i);
	    		if (touch.phase == TouchPhase.Began) {
	    			//タッチした位置からRayを飛ばす
	    			Vector2 worldPoint = Camera.main.ScreenToWorldPoint(touch.position);
	    			RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

	    			if (hit) {
	    				//Rayを飛ばしてあたったオブジェクトが自分自身だったら
	    				if (hit.collider.gameObject == this.gameObject) {
	    					touchNo = touch.fingerId;
	    					OnTouchDown();
	    					return;
	    				}
	    			}
    			} else if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved) {
    				if(touchNo == touch.fingerId && this.IsHold) {
    					Vector2 worldPoint = Camera.main.ScreenToWorldPoint(touch.position);
    					OnTouchDrag(worldPoint);
    				}
    			} else {
    				if(touchNo == touch.fingerId && this.IsHold) {
    					touchNo = -1;
    					OnTouchUp();
    				}
    			}
    		}         
        }
    }

	protected virtual void OnStart() {}
	protected virtual void OnUpdate() {}

	public virtual void StartSimulation() {}
	public virtual void EndSimulation() {}
	public virtual void RemoveObject() {}
}