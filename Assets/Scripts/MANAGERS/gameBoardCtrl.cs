using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameBoardCtrl : MonoBehaviour {
	public int numKnives = 12;
	public int currentKnife = 0;
	public List<GameObject> knives = new List<GameObject>();

  public GameObject knife;
  public int gameIsWon = 0;
	private Vector2 defaultKnifeStartPos = new Vector2(0.0f, -5.263408f);



	void Start () {
		for (int i = 0; i < numKnives; i++) {
			knives.Add(knife);
		}
		DequeueKnife();
	}

	void Update () {
	}

	// Note: This only occurs when knife hits "knife_hit_wheel"
	public void DequeueKnife()
	{
		if(knives.Count > 0)
		{
			GameObject k = knives[0];
			knives.RemoveAt(0);
			InstantiateKnife(k);
			currentKnife++;
		}
		else
		{
			SetWinLossStatus(1);
		}
	}

	public void CheckWinLossStatus() {

	}

	public void SetWinLossStatus(int i) {
		gameIsWon = i;
	}

	GameObject InstantiateKnife(GameObject listKnife, Vector2? knifeStartPos = null, bool? isDocked = false) {
		Vector2 startPosition;

		if (knifeStartPos == null) {
			startPosition = defaultKnifeStartPos;
		} else {
			startPosition = (Vector2) knifeStartPos;
		}

		GameObject k = Instantiate(listKnife, defaultKnifeStartPos, transform.rotation);
		k.name = "knife_0" + currentKnife;
		k.transform.parent = gameObject.transform;
		k.GetComponent<knifeCtrl>().isDocked = (bool) isDocked;

		return k;
	}
}
