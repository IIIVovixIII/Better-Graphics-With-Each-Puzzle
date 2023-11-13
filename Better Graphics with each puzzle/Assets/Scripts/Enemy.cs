using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust the speed as needed
    public Transform leftPoint; // Left limit of movement
    public Transform rightPoint; // Right limit of movement

    private bool movingRight = true;

    void Update()
    {
        // Move the enemy
        if (movingRight)
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        else
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

        // Check if the enemy reached the limits
        if (transform.position.x >= rightPoint.position.x)
        {
            movingRight = false;
        }
        else if (transform.position.x <= leftPoint.position.x)
        {
            movingRight = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collided object is the player
        if (collision.gameObject.tag == "Wall")
        {
            // Restart the scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
