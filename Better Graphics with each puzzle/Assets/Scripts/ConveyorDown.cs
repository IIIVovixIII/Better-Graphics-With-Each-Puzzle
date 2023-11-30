using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorDown : MonoBehaviour
{
    public float Speed = 10f;

    private void OnTriggerStay2D(Collider2D other)
    {
        // Check if the player collides with the conveyor
        if (other.CompareTag("Player"))
        {
            Rigidbody2D playerRB = other.GetComponent<Rigidbody2D>();

            if (playerRB != null)
            {
                // Apply a force to move the player forward
                playerRB.velocity = new Vector2(playerRB.velocity.x, Speed);
            }
        }
    }
}