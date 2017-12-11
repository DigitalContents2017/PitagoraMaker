using UnityEngine;
using System.Collections.Generic;

class Domino : Block
{
  List<Rigidbody2D> rigidbodys = new List<Rigidbody2D>();

  void Start()
  {
    base.Start();
    rigidbodys.AddRange(GetComponentsInChildren<Rigidbody2D>());
    foreach (var rigid in rigidbodys)
    {
      rigid.constraints = RigidbodyConstraints2D.FreezeAll;
    }
  }

  public override void StartSimulation()
  {
    base.StartSimulation();
  }

  public override void EndSimulation()
  {
    base.EndSimulation();
  }
}

