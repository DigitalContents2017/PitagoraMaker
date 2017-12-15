using System;
using UnityEngine;

class Block : PitagoraObject {
	const float GLID_SIZE = 1.0f;

	int indexX, indexY;

	Collider2D ObjectCollider;
	BoxCollider2D BoxCollider;

	public override void OnStart() {
		prevPos = this.transform.localPosition;
		ObjectCollider = GetComponent<Collider2D>();
		if (ObjectCollider != null)
		{
			ObjectCollider.enabled = false;
		}
		BoxCollider = gameObject.AddComponent<BoxCollider2D>();
		BoxCollider.size = new Vector2(1, 1);
	}

	public override void StartSimulation() {
		base.StartSimulation();
		isSimulating = true;
		prevPos = this.transform.localPosition;
		rotation = this.transform.rotation;
		if (ObjectCollider != null)
		{
			ObjectCollider.enabled = true;
		}
		BoxCollider.enabled = false;
	}

	public override void EndSimulation()
	{
		base.EndSimulation();
		isSimulating = false;
		this.transform.localPosition = prevPos;
		this.transform.rotation = rotation;
		if (ObjectCollider != null)
		{
			ObjectCollider.enabled = false;
		}
		BoxCollider.enabled = true;
	}

	protected override void OnObjectReleased() {
		base.OnObjectReleased();

		if (!isSimulating)
		{
			if (IsTrashed())
			{
				StageManager.RemoveObject(prevPos);
				Destroy(gameObject);
				return;
			}

			Vector3 glidPos = GetFitGlidPos();
			var result = StageManager.SetObject(glidPos);

			if (result)
			{
				StageManager.RemoveObject(prevPos);
				transform.position = glidPos;
				prevPos = glidPos;
			}
			else
			{
				this.transform.localPosition = prevPos;
				this.transform.rotation = rotation;
			}
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
