using UnityEngine;
using System.Collections;

class RigidBlock : Block
{
  Rigidbody2D rigidbody;

	void Start()
	{
    base.Start();
    rigidbody = GetComponent<Rigidbody2D>();
    rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
	}

  public override void StartSimulation()
  {
    base.StartSimulation();
    if(!isButton)
    {
      rigidbody.constraints = RigidbodyConstraints2D.None;
    }
  }

  public override void EndSimulation()
  {
    base.EndSimulation();
    rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
  }
}
