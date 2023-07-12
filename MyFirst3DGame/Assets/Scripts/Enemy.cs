using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : MonoBehaviour
{
    public float speed;
    public Vector3 moveOffset;
    private Vector3 targetPos;
    private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        targetPos = startPos;
    }
    // Update is called once per frame
    void Update()
    {
        // Move towards the target position.
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        // Did we reach the target position?
        if (transform.position == targetPos)
        {
            // Ping pong between startPos and startPos + moveOffset.
            if (targetPos == startPos)
            {
                targetPos = startPos + moveOffset;
            }
            else
            {
                targetPos = startPos;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        // Did the player enter our trigger?
        if (other.CompareTag("Player"))
        {
            // Call player game over.
            other.GetComponent<PlayerController>().GameOver();
        }
    }
}