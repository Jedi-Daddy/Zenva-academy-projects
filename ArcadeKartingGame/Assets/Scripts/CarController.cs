using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarController : MonoBehaviour
{
    public float acceleration;
    public float turnSpeed;

    public Transform carModel;
    private Vector3 startModelOffset;

    public float groundCheckRate;
    private float lastGroundCheckTime;

    private float curvYRot;

    private bool accelerateInput;
    private float turnInput;

    public Rigidbody rig;

    void Start()
    {
        startModelOffset = carModel.transform.localPosition;
    }

    void Update()
    {
        curvYRot += turnInput * turnSpeed * Time.deltaTime;

        //Debug.Log("Accelerating: " + accelerateInput + ", Turn: " + turnInput);
        carModel.position = transform.position + startModelOffset;
        carModel.eulerAngles = new Vector3(0,curvYRot,0);
    }

    // 60 times per seconds
    void FixedUpdate()
    {
        if(accelerateInput == true)
        {
            rig.AddForce(carModel.forward * acceleration, ForceMode.Acceleration);
        }
    }

    public void OnAccelerateInput(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
            accelerateInput = true;
        else
            accelerateInput = false;
    }

    public void OnTurnInput (InputAction.CallbackContext context)
    {
        turnInput = context.ReadValue<float>();
    }
}
