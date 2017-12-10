﻿using System;
using UnityEngine;

class Block : PitagoraObject {
  const float GLID_SIZE = 1.0f;
  bool isSimulating = false;

  int indexX, indexY;
  Vector3 prevPos;
  Quaternion prevRotation;
  public bool isButton = false; //tureならUI上のボタン

  protected void Start() {
    prevPos = this.transform.localPosition;
    prevRotation = this.transform.rotation;
  }

  void OnMouseDown() {
    prevPos = this.transform.localPosition;
    prevRotation = this.transform.rotation;
  }

  public override void StartSimulation() {
    base.StartSimulation();
    isSimulating = true;
  }

  public override void EndSimulation()
  {
    base.EndSimulation();
    isSimulating = false;
    this.transform.localPosition = prevPos;
    this.transform.rotation = prevRotation;
  }

  void OnMouseDrag()
  {
    if (!isSimulating) {
      Vector3 screenPos = Input.mousePosition;
      Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
      worldPos.z = 0;
      transform.position = worldPos;
    }
  }

  void OnMouseUp()
  {
    if (IsTrashed())
    {
      StageManager.RemoveObject(prevPos);
      Destroy(gameObject);
      return;
    }

    Vector3 glidPos = GetFitGlidPos();
    var result = StageManager.SetObject(glidPos);
    isButton = false;

    if(result) {
      StageManager.RemoveObject(prevPos);
      transform.position = glidPos;
      prevPos = glidPos;
    } else {
      this.transform.localPosition = prevPos;
      this.transform.rotation = prevRotation;
    }
  }

  Vector3 GetFitGlidPos() {
    Vector3 diff = new Vector3(transform.position.x % GLID_SIZE, transform.position.y % GLID_SIZE, 0);
    Vector3 glidPos = new Vector3(transform.position.x - diff.x, transform.position.y - diff.y, 0);

    if (diff.x > GLID_SIZE / 2)
    {
      glidPos.x += GLID_SIZE;
    }
    else if (diff.x < -(GLID_SIZE / 2))
    {
      glidPos.x -= GLID_SIZE;
    }

    if (diff.y > GLID_SIZE / 2)
    {
      glidPos.y += GLID_SIZE;
    }
    else if (diff.y < -(GLID_SIZE / 2))
    {
      glidPos.y -= GLID_SIZE;
    }

    return glidPos;
  }

  bool IsTrashed() {
    GameObject trash = GameObject.Find("Trash");
    Canvas canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
    Vector3 trashScreenPos = Camera.main.WorldToScreenPoint(trash.transform.position);
    Vector3 mouseScreenPos = Input.mousePosition;
    float width = trash.GetComponent<RectTransform>().rect.width * canvas.scaleFactor;
    float height = trash.GetComponent<RectTransform>().rect.height * canvas.scaleFactor;
    if(Math.Abs(trashScreenPos.x - mouseScreenPos.x) < width / 2 &&
       Math.Abs(trashScreenPos.y - mouseScreenPos.y) < height / 2) {
      return true;
    }
    return false;
  }
}
