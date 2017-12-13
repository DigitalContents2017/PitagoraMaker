using System;
using UnityEngine;

class Goal : MonoBehaviour {
	void Start() {
		StageManager.SetObject(transform.position);
	}

	void OnCollisionEnter2D(Collision2D collision){
		Debug.Log("Hit");
	}
}