using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public Rigidbody rig;
    private bool isGrounded;

    public int score;

    public TextMeshProUGUI scoreText;

    // Update is called once per frame
    void Update()
    {
        // Get the keyboard inputs.
        float x = Input.GetAxisRaw("Horizontal") * moveSpeed;
        float z = Input.GetAxisRaw("Vertical") * moveSpeed;
        // Set out velocity (move the player).
        rig.velocity = new Vector3(x, rig.velocity.y, z);
        // Create a temporary velocity vector and cancel out the Y.
        Vector3 vel = rig.velocity;
        vel.y = 0;
        // If we are moving, rotate to face that direction.
        if (vel.x != 0 || vel.z != 0)
        {
            transform.forward = vel;
        }
        // If we press SPACE and we are on the ground, jump.
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            isGrounded = false;
            rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if(transform.position.y < -5)
        {
            GameOver();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        // If we collided with a ground surface, we are grounded.
        if (collision.GetContact(0).normal == Vector3.up)
        {
            isGrounded = true;
        }
    }
    // Called when an enemy hits us, or we fall off the level.
    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AddScore (int amount)
    {
        score += amount;
        scoreText.text = score.ToString();
    }
}