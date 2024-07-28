using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballon : MonoBehaviour
{
    public int clicksToPop;

    void OnMouseDown()
    {
        clicksToPop -= 1;

        transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);

        if (clicksToPop == 0)
        {
            Destroy(gameObject);
        }
    }
}