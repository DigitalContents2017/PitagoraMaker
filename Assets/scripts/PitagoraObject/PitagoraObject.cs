using System;
using UnityEngine;

public class PitagoraObject : MonoBehaviour {

	protected Quaternion prevRot;
	protected Vector3 prevPos;

	// 静的なオブジェクト
	public bool IsStatic = false;

	protected bool IsInstalled = false;
	
	// ゴールに影響を与えるオブジェクト
	public bool IsMotion = false;
	
	public bool IsChild = false;

	void Start() {
    	OnStart();
	}

	void Update() {
		OnUpdate();
	}

	protected virtual void OnStart() {}
	protected virtual void OnUpdate() {}

	public virtual void StartSimulation() {}
	public virtual void EndSimulation() {}
	public virtual void RemoveObject() {}
}