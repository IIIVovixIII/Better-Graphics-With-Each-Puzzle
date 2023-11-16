using UnityEngine;

public class UnlockRotation : MonoBehaviour
{
    private bool canUnlockRotation = false;

    private void Update()
    {
        if (canUnlockRotation)
        {
            UnlockPlayerRotation();
            canUnlockRotation = false; // Reset the flag after unlocking rotation
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player collides with the object
        if (collision.gameObject.CompareTag("Player"))
        {
            // Set the flag to unlock rotation
            canUnlockRotation = true;
        }
    }

    private void UnlockPlayerRotation()
    {
        Rigidbody2D playerRB = GetComponent<Rigidbody2D>();

        if (playerRB != null)
        {
            // Get the current constraints
            RigidbodyConstraints2D constraints = playerRB.constraints;

            // Remove the constraint on rotation around the Z-axis
            constraints &= ~RigidbodyConstraints2D.FreezeRotation;

            // Apply updated constraints
            playerRB.constraints = constraints;
        }
    }
}
