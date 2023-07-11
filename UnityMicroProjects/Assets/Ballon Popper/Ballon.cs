using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballon : MonoBehaviour
{
    public int scoreToGive = 1;
    public int clicksToPop = 5;
    public float scaleIncreasePerClick = 0.1f;
    public ScoreManager scoreManager;

    void OnMouseDown ()
    {
        clicksToPop -= 1;

        transform.localScale += Vector3.one * scaleIncreasePerClick;

        if(clicksToPop == 0)
        {
            scoreManager.IncreaseScore (scoreToGive);
            Destroy(gameObject);
        }
    }
}
