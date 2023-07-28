using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    public TextMeshProUGUI carPositionText;
    public CarController car;

    void Update()
    {
        carPositionText.text = car.racePosition.ToString() + " / " + GameManager.Instance.cars.Count.ToString();
    }
}
