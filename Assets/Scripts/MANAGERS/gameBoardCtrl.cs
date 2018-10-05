
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameBoardCtrl : MonoBehaviour
{
    private Vector2 defaultKnifeStartPos = new Vector2(0.0f, -5.263408f);
    private Vector2 defaultBlackKnifeStartPos = new Vector2(-7.0f, 0.0f);
    private static int BLACK_KNIFE_SPACING = 1;
    public static int SCORE_INCREMENT = 10;

    public int currentKnife = 0;
    public int numKnives = 12;
    public int gameIsWon = 0;
    public int score = 0;

    public GameObject blackKnife;
    public GameObject knife;
    public List < GameObject > knives = new List < GameObject > ();
    public List < GameObject > blackKnives = new List < GameObject > ();
    public Text scoreText;

    void Start()
    {
        Vector2 adjustedBlackKnifePosition = defaultBlackKnifeStartPos;
        scoreText.text = "Score: " + score.ToString();
        for (int i = 0; i < numKnives; i++)
        {
            adjustedBlackKnifePosition.y -= BLACK_KNIFE_SPACING;
            knives.Add(knife);
            GameObject bk = Instantiate(blackKnife, adjustedBlackKnifePosition, transform.rotation);
            bk.transform.parent = gameObject.transform;

            blackKnives.Add(bk);
        }
        DequeueKnife();
    }

    void Update()
    {}

    // Note: This only occurs when knife hits "knife_hit_wheel"
    public void DequeueKnife()
    {
        if (knives.Count > 0)
        {
            GameObject k = knives[0];
            GameObject bk = blackKnives[0];

            knives.RemoveAt(0);
            blackKnives.RemoveAt(0);

            InstantiateKnife(k);
            Destroy(bk);

            currentKnife++;
        }
        else
        {
            SetWinLossStatus(1);
        }
    }

    public void CheckWinLossStatus()
    {

    }

    public void SetWinLossStatus(int i)
    {
        gameIsWon = i;
    }

    public void IncrementScore()
    {
      score += SCORE_INCREMENT;
      scoreText.text = "Score: " + score.ToString();
    }

    public void DecrementScore()
    {
      score -= SCORE_INCREMENT;
      scoreText.text = "Score: " + score.ToString();
    }

    GameObject InstantiateKnife(GameObject listKnife, Vector2 ? knifeStartPos = null, bool ? isDocked = false)
    {
        Vector2 startPosition;

        if (knifeStartPos == null)
        {
            startPosition = defaultKnifeStartPos;
        }
        else
        {
            startPosition = (Vector2) knifeStartPos;
        }

        GameObject k = Instantiate(listKnife, defaultKnifeStartPos, transform.rotation);
        k.name = "knife_0" + currentKnife;
        k.transform.parent = gameObject.transform;
        k.GetComponent < knifeCtrl > ().isDocked = (bool) isDocked;

        return k;
    }

    // GameObject InstantiateBlackKnives()
    // {
    //   Vector2 adjustedPosition;
    //   for(int i = (numKnives - 1); i >= 0; i--)
    //   {
    //     GameObject bk = blackKnives[i];
    //     blackKnives.RemoveAt(i);
    //     adjustedPosition = defaultBlackKnifeStartPos;
    //     adjustedPosition.x -= i;
    //     GameObject blackKnife = Instantiate(bk, (defaultBlackKnifeStartPos - i) , transform.rotation);
    //     blackKnife.transform.parent = gameObject.transform;
    //   }
    // }
}
