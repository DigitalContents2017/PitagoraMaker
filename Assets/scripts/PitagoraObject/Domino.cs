using System;
using System.Collections;
using UnityEngine;

class Domino : MovableObject {

	ChildDomino[] childDominos;

	protected override void OnStart() {
		base.OnStart();
		childDominos = this.GetComponentsInChildren<ChildDomino>();
	}

	public override void StartSimulation() {
		base.StartSimulation();

		foreach(var childDomino in childDominos) {
			childDomino.StartSimulation();
		}
	}

	public override void EndSimulation() {
		base.EndSimulation();

		foreach(var childDomino in childDominos) {
			childDomino.EndSimulation();
		}
	}
}
