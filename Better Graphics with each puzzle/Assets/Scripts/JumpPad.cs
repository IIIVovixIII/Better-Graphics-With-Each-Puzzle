using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float jumpForce = 10f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player collides with the jump pad
        if (other.CompareTag("Player"))
        {
            Rigidbody2D playerRB = other.GetComponent<Rigidbody2D>();

            if (playerRB != null)
            {
                // Apply a force to make the player jump
                playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
            }
        } 
    }
}
