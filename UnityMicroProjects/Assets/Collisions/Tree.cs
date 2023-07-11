using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public MeshRenderer mr;
    public Color hitColor;

    void OnCollisionEnter (Collision collision) 
    {
        mr.material.color = hitColor;
    }

}
