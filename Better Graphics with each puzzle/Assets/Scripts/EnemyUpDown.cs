using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyUpDown : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public float moveDistance = 5.0f; // Adjust this to control how far it moves
    public bool startMovingRight = true;

    private bool movingRight;
    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
        movingRight = startMovingRight;
    }

    private void Update()
    {
        // Calculate the distance between the current position and the initial position
        float distance = transform.position.y - initialPosition.y;

        // Check if the enemy should change direction
        if (distance >= moveDistance)
        {
            movingRight = false;
        }
        else if (distance <= -moveDistance)
        {
            movingRight = true;
        }

        // Move the enemy left or right based on the direction
        if (movingRight)
        {
            transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the enemy touches the player (assuming the player has a "Player" tag)
        if (other.CompareTag("Player"))
        {
            // Reset the scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
