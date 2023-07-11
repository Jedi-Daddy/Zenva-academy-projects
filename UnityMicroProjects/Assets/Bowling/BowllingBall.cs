using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowllingBall : MonoBehaviour
{
    public float forwardForce;
    public float leftBorder;
    public float rightBorder;
    public float moveIncrement;
    public Rigidbody rig;


    public void Bowl ()
    {
        rig.AddForce(transform.forward * forwardForce, ForceMode.Impulse);
    }

    public void MoveLeft()
    {
        if (transform.position.x > leftBorder)
        {
            transform.position += new Vector3(-moveIncrement, 0, 0);
        }

    }
    public void MoveRight()
    {
        if (transform.position.x < rightBorder)
        {
            transform.position += new Vector3(moveIncrement, 0, 0);
        }
    }
}

