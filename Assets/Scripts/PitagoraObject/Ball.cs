using UnityEngine;
using System.Collections;

class Ball : MovableObject {

	public override void StartSimulation() {
		base.StartSimulation();
		this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
	}

	public override void EndSimulation() {
		base.EndSimulation();
		this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
	}
}