using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheelCtrl : MonoBehaviour {

	public float rotateSpeedMultiplier = 4;
	public CircleCollider2D circleCollider2D;
	public GameObject knife;

	void Start () 
	{
		circleCollider2D = gameObject.GetComponent<CircleCollider2D>();

		//gameObject.transform.parent.
		//Debug.Log("radius: " + circleCollider2D.radius);
		//Debug.Log("offset: " + circleCollider2D.offset);

		GameObject k0 = InstantiateDockedKnife(new Vector2(1.8f, circleCollider2D.radius));
		GameObject k1 = InstantiateDockedKnife(new Vector2(-1.8f, circleCollider2D.radius));
		GameObject k2 = InstantiateDockedKnife(new Vector2(1.8f, -circleCollider2D.radius));
		GameObject k3 = InstantiateDockedKnife(new Vector2(-1.8f, -circleCollider2D.radius));
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
    
	GameObject InstantiateDockedKnife(Vector2 knifeStartPos)
    {
		GameObject k = Instantiate(knife, knifeStartPos, Quaternion.Euler(0.0f, 0.0f, 90.0f));

		k.name = "docked_knife_0";
        k.transform.parent = transform;
        
        //Find angle between bottom of circle and whereve knife is on circle
		Vector2 circleColliderRight = new Vector2(circleCollider2D.radius, 0.0f);
		int angleMultiplier = knifeStartPos.y >= 0 ? 1 : -1;
		float angle = Vector2.Angle(circleColliderRight, knifeStartPos);

		k.transform.Rotate(new Vector3(0, 0, angle * angleMultiplier));
        k.GetComponent<knifeCtrl>().isDocked = true;

        return k;
    }
}
