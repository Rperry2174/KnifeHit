using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameBoardCtrl : MonoBehaviour {
	public static int NUM_KNIVES = 12;
	public int currentKnife = 0;
    public GameObject knife;
    public int gameIsWon = 0;

	private Vector2 defaultKnifeStartPos = new Vector2(0.0f, -5.263408f);

	void Start (){
		GetNextKnife();
	}
    
	void Update () {
	}

	// Note: This only occurs when knife hits "knife_hit_wheel"
	public void GetNextKnife() 
	{
		if(currentKnife < NUM_KNIVES)
		{
			GameObject k = InstantiateKnife(currentKnife);
			currentKnife += 1;
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
    
	GameObject InstantiateKnife(int i, Vector2? knifeStartPos = null, bool? isDocked = false) {
		Vector2 startPosition;
		if (knifeStartPos == null) {
			startPosition = defaultKnifeStartPos;
		} else {
			startPosition = (Vector2) knifeStartPos;
		}
		GameObject k = Instantiate(knife, defaultKnifeStartPos, transform.rotation);
		k.name = "knife_0" + i;
		k.transform.parent = gameObject.transform;
		k.GetComponent<knifeCtrl>().isDocked = (bool) isDocked;

		return k;
	}
}
