using UnityEngine;

public class PitagoraObject : MonoBehaviour
{
  const float GLID_SIZE = 1.0f;

  int indexX, indexY;
  Vector3 prevPos;

  void OnMouseDown() {
    prevPos = this.transform.localPosition;
  }

  void OnMouseDrag()
  {
    Vector3 screenPos = Input.mousePosition;
    Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
    worldPos.z = 0;
    transform.position = worldPos;
  }

  void OnMouseUp()
  {
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

    int _indexX = (int)glidPos.x;
    int _indexY = (int)glidPos.y;

    if(!StageManager.stage[_indexX, _indexY]) {
      StageManager.stage[indexX, indexY] = false;
      StageManager.stage[_indexX, _indexY] = true;

      indexX = _indexX;
      indexY = _indexY;
      
      transform.position = glidPos;
    } else {
      this.transform.localPosition = prevPos;
    }
   
  }
}
