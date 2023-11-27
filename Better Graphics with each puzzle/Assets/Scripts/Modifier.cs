using UnityEngine;

public class Modifier : MonoBehaviour
{
    public float jumpPowerIncrease = 5f; // Adjust this value as needed

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player enters the trigger zone (assuming the player has a "Player" tag)
        if (other.CompareTag("Player"))
        {
            // Get the Player's Move script
            Move playerMoveScript = other.GetComponent<Move>();

            // Check if the player's Move script is found
            if (playerMoveScript != null)
            {
                // Increase the player's jump power
                playerMoveScript.jumpForce += jumpPowerIncrease;
            }

            // Disable the platform so it cannot affect the jump power again
            gameObject.SetActive(false);
        }
    }
}
