using UnityEngine;

public class CherryMove : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float normalGravityScale = 1f;
    public float climbSpeed = 5f;
    private bool isClimbing = false;
    public AudioSource boing;
    public bool doBoing = true;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool hasJumped;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = normalGravityScale; // Set initial gravity scale
    }

    void Update()
    {
        // Check if the player is grounded
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.1f, groundLayer);

        // Get input from the arrow keys or WASD
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate the movement direction
        Vector2 movement = new Vector2(horizontalInput, 0);
        if (isClimbing)
        {
            float inputVertical = Input.GetAxis("Vertical");
            rb.velocity = new Vector2(rb.velocity.x, inputVertical * climbSpeed);
            //transform.rotation = Quaternion.Euler(0, 0, 90); // Rotate the player to 18 degrees

        }
        // Move the GameObject
        transform.Translate(movement * speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            // Apply a downward force
            rb.velocity = new Vector2(rb.velocity.x, -jumpForce); // Use the jumpForce for a consistent effect
        }
        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            // Reset the downward force if required, or reset the gravity scale
            rb.velocity = new Vector2(rb.velocity.x, 0); // Stop the extra downward movement
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            if (!doBoing)
            {
                doBoing = true;
            }
            else
            {
                doBoing = false;
            }
        }

        // Check for jump input and if the player is grounded
        if (Input.GetButtonDown("Jump") && isGrounded && !hasJumped)
        {
            if (doBoing == true)
            {
                boing.Play();
            }
            Jump();
            hasJumped = true;
        }

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
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Reset the hasJumped flag when colliding with the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            hasJumped = false;
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            isClimbing = true;
            rb.gravityScale = 0; // Remove gravity effect while climbing
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            isClimbing = false;
            rb.gravityScale = 1; // Reset gravity scale
        }
    }

}
