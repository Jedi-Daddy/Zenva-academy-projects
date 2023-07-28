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
        float turnRate = Vector3.Dot(rig.velocity.normalized, carModel.forward);
        turnRate = Mathf.Abs(turnRate);

        curvYRot += turnInput * turnSpeed * turnRate * Time.deltaTime;

        //Debug.Log("Accelerating: " + accelerateInput + ", Turn: " + turnInput);
        carModel.position = transform.position + startModelOffset;
        //carModel.eulerAngles = new Vector3(0,curvYRot,0);

        CheckGround();
    }

    // 60 times per seconds
    void FixedUpdate()
    {
        if(accelerateInput == true)
        {
            rig.AddForce(carModel.forward * acceleration, ForceMode.Acceleration);
        }
    }

    void CheckGround()
    {
        Ray ray = new Ray(transform.position + new Vector3(0, -0.75f, 0), Vector3.down);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 1.0f))
        {
            carModel.up = hit.normal;
        }
        else
        {
            carModel.up = Vector3.up;
        }

        carModel.Rotate(new Vector3(0,curvYRot, 0), Space.Self);
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
