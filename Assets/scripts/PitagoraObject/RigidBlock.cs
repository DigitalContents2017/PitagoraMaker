using UnityEngine;
using System.Collections;

class RigidBlock : Block
{
	Rigidbody2D rigidbody;

	public override void StartSimulation()
	{
		base.StartSimulation();
		this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
	}

	public override void EndSimulation()
	{
		base.EndSimulation();
		this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
	}
}