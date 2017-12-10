using UnityEngine;
using System.Collections;

class RigidBlock : Block
{
  Rigidbody2D rigidbody;
  Vector2 savedPosition;
  Quaternion savedRotation;

	void Start()
	{
    rigidbody = GetComponent<Rigidbody2D>();
    rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
	}

  public override void StartSimulation()
  {
    savedPosition = new Vector2(transform.position.x, transform.position.y);
    savedRotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);

    if(!isButton)
    {
      rigidbody.constraints = RigidbodyConstraints2D.None;
    }
  }

  public override void EndSimulation()
  {
    rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
    transform.position = savedPosition;
    transform.rotation = savedRotation;
  }
}
