using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheelCtrl : MonoBehaviour {

	private float[] angles = new float[] {0.0f, 120.0f, 240.0f};
	public float rotateSpeedMultiplier = 4;
	public CircleCollider2D circleCollider2D;
	public GameObject dockedKnife;
	public Vector2 circleColliderRight;


	void Start ()
	{
		circleCollider2D = gameObject.GetComponent<CircleCollider2D>();
		circleColliderRight = new Vector2(circleCollider2D.radius, 0.0f);

		foreach (float angle in angles){
			GameObject k0 = InstantiateDockedKnife(angle);
		}
	}

	Vector2 angleToVector2 (float angle)
	{
		int xDirection = (angle <= 90.0f || angle >= 270.0f) ? 1 : -1;
		int yDirection = angle < 180.0f ? 1 : -1;

		float x = circleCollider2D.radius * Mathf.Cos(angle) * xDirection;
		float y = circleCollider2D.radius * Mathf.Sin(angle) * yDirection;

		return new Vector2(x, y);
	}

	float Vector2ToAngle (Vector2 point)
	{
		return Vector2.Angle(circleColliderRight, point);
	}

	float addDockedKnifeToWheel (float angle) {
		float totalAngle = gameObject.transform.rotation.z + angle;
		if (totalAngle >= 360.0f) {
			return totalAngle - 360.0f;
		} else {
			return totalAngle;
		}
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

	GameObject InstantiateDockedKnife(float angle)
	{
		Vector2 dockedKnifeStartPos = angleToVector2(angle);
		// If you need to access knife height
		// float knifeHeight = dockedKnife.GetComponent<BoxCollider2D>().size.y;
		// dockedKnifeStartPos.y = dockedKnifeStartPos.y + knifeHeight;

		GameObject k = Instantiate(dockedKnife, dockedKnifeStartPos, Quaternion.Euler(0.0f, 0.0f, 90.0f));

		k.name = "docked_knife_0";
    k.transform.parent = transform;

    // Find angle between bottom of circle and whereve knife is on circle
		int angleMultiplier = dockedKnifeStartPos.y >= 0 ? 1 : -1;
		float rotation = Vector2ToAngle(dockedKnifeStartPos);

		k.transform.Rotate(new Vector3(0, 0, rotation * angleMultiplier));
    return k;
  }
}
