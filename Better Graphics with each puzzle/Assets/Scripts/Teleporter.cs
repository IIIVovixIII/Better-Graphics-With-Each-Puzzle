using UnityEngine;

public class Teleporter : MonoBehaviour
{
    // Reference to the destination teleportation platform
    public Transform destinationPlatform;

    // Called when a player enters the platform trigger collider
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object entering the trigger is the player (you can customize the tag or layer)
        if (other.CompareTag("Player"))
        {
            // Teleport the player to the destination platform
            TeleportPlayer(other.transform);
        }
    }

    // Teleport the player to the destination platform
    private void TeleportPlayer(Transform playerTransform)
    {
        // Set the player's position to the destination platform's position
        playerTransform.position = destinationPlatform.position;

        // Optionally, add any extra effects or animations here
    }
}
