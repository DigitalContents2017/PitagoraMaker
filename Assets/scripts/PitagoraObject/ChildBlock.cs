using System;
using UnityEngine;

class ChildBlock : PitagoraObject
{
	Quaternion prevRotation;
	Collider2D ObjectCollider;
	public bool isFreeze = false;

	void Start()
	{
		GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
		ObjectCollider = GetComponent<Collider2D>();
		if (ObjectCollider != null)
		{
			ObjectCollider.enabled = false;
		}
	}

	public override void StartSimulation()
	{
		base.StartSimulation();
		if(!isFreeze) {
			prevPos = transform.localPosition;
			prevRotation = transform.rotation;
			GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
			if (ObjectCollider != null)
			{
				ObjectCollider.enabled = true;
			}
		}
	}

	public override void EndSimulation()
	{
		base.EndSimulation();
		if (!isFreeze)
		{
			GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
			transform.localPosition = prevPos;
			transform.rotation = prevRotation;
			if (ObjectCollider != null)
			{
				ObjectCollider.enabled = false;
			}
		}
	}
}
