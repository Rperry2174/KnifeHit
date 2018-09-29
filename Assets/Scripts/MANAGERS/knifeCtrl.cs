using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knifeCtrl : MonoBehaviour {

	public Rigidbody2D rb;
	public GameObject gameBoard;
	public int gravityScale = -1;
	public bool isDocked;

	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D>();
		isDocked = gameObject.tag == "DockedKnife";
	}

	void Update () {
		if (Input.GetMouseButtonDown(0) && rb != null) {
			rb.gravityScale = gravityScale;
		}
	}

	void OnCollisionEnter2D(Collision2D col) {
		Debug.Log("contact point :" + col.contacts[0].normal);
		switch (col.gameObject.tag)
		{
		case "Wheel":
			gameBoard = col.gameObject.transform.parent.gameObject;
			// Successfully hit knife_hit_wheel
			Destroy(rb);
			gameObject.tag = "DockedKnife";

			// Set knife_hit_wheel as parent of knife
			gameObject.transform.parent = col.gameObject.transform;

			// iterate gameboard to next knife
			gameBoard.GetComponent<gameBoardCtrl>().GetNextKnife();
			break;
		case "DockedKnife":
			gameBoard = col.gameObject.transform.parent.parent.gameObject;
			Debug.Log("knife gameboard: " + gameBoard);
			gameBoard.GetComponent<gameBoardCtrl>().SetWinLossStatus(-1);
			Destroy(gameObject);
			break;
		case "bonus":
			break;
		}
	}
}
