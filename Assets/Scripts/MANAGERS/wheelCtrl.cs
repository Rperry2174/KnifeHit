using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheelCtrl : MonoBehaviour {

	public float rotateSpeedMultiplier = 4;
	public CircleCollider2D circleCollider2D;
	public GameObject dockedKnife;

	void Start ()
	{
		circleCollider2D = gameObject.GetComponent<CircleCollider2D>();

		float angle = 50.0f;
		float x = circleCollider2D.radius * Mathf.Cos(angle);
		float y = circleCollider2D.radius * Mathf.Sin(angle);

		Vector2 angleMadeKnife = new Vector2(x, y);
		GameObject k0 = InstantiateDockedKnife(angleMadeKnife);
	}

	void Update ()
	{
		RotateRight();
	}

	void RotateRight()
  {
		Vector3 theRotation = new Vector3(0, 0, -1 * rotateSpeedMultiplier);
		transform.Rotate(theRotation);
  }

	GameObject InstantiateDockedKnife(Vector2 dockedKnifeStartPos)
	{
		// If you need to access knife height
		// float knifeHeight = dockedKnife.GetComponent<BoxCollider2D>().size.y;
		// dockedKnifeStartPos.y = dockedKnifeStartPos.y + knifeHeight;

		GameObject k = Instantiate(dockedKnife, dockedKnifeStartPos, Quaternion.Euler(0.0f, 0.0f, 90.0f));

		k.name = "docked_knife_0";
    k.transform.parent = transform;

    // Find angle between bottom of circle and whereve knife is on circle
		Vector2 circleColliderRight = new Vector2(circleCollider2D.radius, 0.0f);
		int angleMultiplier = dockedKnifeStartPos.y >= 0 ? 1 : -1;
		float angle = Vector2.Angle(circleColliderRight, dockedKnifeStartPos);

		k.transform.Rotate(new Vector3(0, 0, angle * angleMultiplier));
    return k;
  }
}
