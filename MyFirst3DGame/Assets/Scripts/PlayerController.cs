using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rig;
    public float moveSpeed;
    public float jumpForce;

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal") * moveSpeed;
        float z = Input.GetAxisRaw("Vertical") * moveSpeed;

        rig.velocity = new Vector3(x, rig.velocity.y, z);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
