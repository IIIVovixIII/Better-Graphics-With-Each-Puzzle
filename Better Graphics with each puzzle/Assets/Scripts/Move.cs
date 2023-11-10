using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Check if the player is grounded
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.1f, groundLayer);

        // Get input from the arrow keys or WASD
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate the movement direction
        Vector2 movement = new Vector2(horizontalInput, 0);

        // Normalize the movement vector to ensure consistent speed in all directions
        movement.Normalize();

        // Move the GameObject
        transform.Translate(movement * speed * Time.deltaTime);

        // Check for jump input and if the player is grounded
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
    }

    void Jump()
    {
        // Apply a force to jump
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}
