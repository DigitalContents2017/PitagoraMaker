using UnityEngine;
using System.Collections;

class Ball : MovableObject {

	Rigidbody2D rigidbody;

	protected override void OnStart() {
		base.OnStart();
		rigidbody = this.GetComponent<Rigidbody2D>();
		rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
	}

	public override void StartSimulation() {
		base.StartSimulation();
		rigidbody.constraints = RigidbodyConstraints2D.None;
	}

	public override void EndSimulation() {
		base.EndSimulation();
		rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
	}
}