using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchrRight : MonoBehaviour
{
    public float launchForce = 10f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player collides with the jump pad
        if (other.CompareTag("Player"))
        {
            Rigidbody2D playerRB = other.GetComponent<Rigidbody2D>();

            if (playerRB != null)
            {
                // Apply a force to make the player jump
                playerRB.velocity = new Vector2(launchForce, playerRB.velocity.y);
            }
        }
    }
}
