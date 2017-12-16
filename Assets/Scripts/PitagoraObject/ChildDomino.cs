using System;
using System.Collections;
using UnityEngine;

class ChildDomino : MonoBehaviour {
	Vector3 prevPos;
	Quaternion prevRotation;

	void Start() {
		this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
	}

	public void StartSimulation() {
		prevPos = this.transform.localPosition;
		prevRotation = this.transform.localRotation;
		this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
	}

	public void EndSimulation() {
		this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
		this.transform.localPosition = prevPos;
		this.transform.localRotation = prevRotation;
	}
}