using UnityEngine;

public class PitagoraObject : MonoBehaviour
{
  const float GLID_SIZE = 0.5F;

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

    transform.position = glidPos;
  }
}
