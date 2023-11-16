using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool hasJumped;

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
        if (Input.GetButtonDown("Jump") && isGrounded && !hasJumped)
        {
            Jump();
            hasJumped = true;
        }

        // Apply gravity modifications for a more realistic jump feel
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    void Jump()
    {
        // Apply a force to jump
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Reset the hasJumped flag when colliding with the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            hasJumped = false;
        }
    }
}
