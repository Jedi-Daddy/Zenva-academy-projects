using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<CarController> cars = new List<CarController> ();

    public static GameManager Instance;

    void Awake()
    {
        Instance = this;
    }
}
