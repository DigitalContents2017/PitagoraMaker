using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crowd : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 pos = transform.localPosition;
		pos.x -= 0.002f / transform.localScale.x;
		if(pos.x < -22) {
			pos.x = 22;
		}
		transform.localPosition = pos;
	}
}
