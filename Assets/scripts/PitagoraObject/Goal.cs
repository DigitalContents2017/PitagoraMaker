using System;
using UnityEngine;

class Goal : MonoBehaviour {
	void OnCollisionEnter2D(Collision2D collision){
		Debug.Log("Hit");
	}
}