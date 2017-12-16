﻿using System;
using UnityEngine;

public class MovableObject : PitagoraObject {
	const float GLID_SIZE = 1.0f;

	int indexX, indexY;

	Collider2D objectCollider;
	BoxCollider2D touchCollider;

	bool _isTouch = false;
	int touchNo = -1;

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

	protected override void OnStart() {
		base.OnStart();

		objectCollider = this.GetComponent<Collider2D>();
		if (objectCollider != null) {
			objectCollider.enabled = false;
		}

		touchCollider = gameObject.AddComponent<BoxCollider2D>();
		touchCollider.size = new Vector2(1, 1);

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
    		OnMouseDown();
    	}
	}


	protected virtual void OnObjectPressed() {
		Debug.Log("PitagoraObject:OnOnjectPressed()");

		prevPos = this.transform.localPosition;
		prevRot = this.transform.rotation;

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

		if (!Manager.simulationManager.isSimulating) {
			if (IsTrashed()) {
				RemoveObject();
				return;
			}

			Vector3 glidPos = GetFitGlidPos();
			var result = StageManager.SetObject(glidPos);

			if (result) {
				StageManager.RemoveObject(prevPos);
				transform.position = glidPos;
				prevPos = glidPos;
				this.IsInstalled = true;
			} else {
				if(this.IsInstalled) {
					this.transform.localPosition = prevPos;
					this.transform.rotation = prevRot;
				} else {
					RemoveObject();
				}
			}
		}
	}

	protected override void OnUpdate() {
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
	}

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

	public override void StartSimulation() {
		base.StartSimulation();

		prevPos = this.transform.localPosition;
		prevRot = this.transform.rotation;

		if (objectCollider != null) {
			objectCollider.enabled = true;
		}

		if(touchCollider != null) {
			touchCollider.enabled = false;
		}
	}

	public override void EndSimulation() {
		base.EndSimulation();

		this.transform.localPosition = prevPos;
		this.transform.rotation = prevRot;

		if (objectCollider != null) {
			objectCollider.enabled = false;
		}

		if(touchCollider != null) {
			touchCollider.enabled = true;
		}
	}

	public override void RemoveObject() {
		Debug.Log("Block:RemoveObject()");
		StageManager.RemoveObject(prevPos);
		Destroy(gameObject);
	}

	Vector3 GetFitGlidPos() {
		Vector3 diff = new Vector3(this.transform.localPosition.x % GLID_SIZE, this.transform.localPosition.y % GLID_SIZE, 0);
		Vector3 glidPos = new Vector3(this.transform.localPosition.x - diff.x, this.transform.localPosition.y - diff.y, 0);

		if (diff.x > GLID_SIZE / 2)
		{
			glidPos.x += GLID_SIZE;
		}
		else if (diff.x < -(GLID_SIZE / 2))
		{
			glidPos.x -= GLID_SIZE;
		}

		if (diff.y > GLID_SIZE / 2)
		{
			glidPos.y += GLID_SIZE;
		}
		else if (diff.y < -(GLID_SIZE / 2))
		{
			glidPos.y -= GLID_SIZE;
		}

		return glidPos;
	}

		bool IsTrashed() {
			GameObject trash = GameObject.Find("Trash");
			Canvas canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
			Vector3 trashScreenPos = Camera.main.WorldToScreenPoint(trash.transform.position);
			Vector3 mouseScreenPos = Input.mousePosition;
			float width = trash.GetComponent<RectTransform>().rect.width * canvas.scaleFactor;
			float height = trash.GetComponent<RectTransform>().rect.height * canvas.scaleFactor;
			if(Math.Abs(trashScreenPos.x - mouseScreenPos.x) < width / 2 &&
				Math.Abs(trashScreenPos.y - mouseScreenPos.y) < height / 2) {
			return true;
		}
		return false;
	}
}