using UnityEngine;

public class BlueberryMoveLeft : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float normalGravityScale = 1f; // Gravity scale for normal gravity
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

        // Get input from the arrow keys
        float horizontalInput = Input.GetAxis("Horizontal");

        // Move left or right based on arrow key input
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

        // Apply downward force if DownArrow is pressed
        if (Input.GetKeyDown(KeyCode.S))
        {
            rb.velocity = new Vector2(rb.velocity.x, -jumpForce);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }

        // Toggle the boing sound
        if (Input.GetKeyDown(KeyCode.N))
        {
            doBoing = !doBoing;
        }

        // Check for jump input (UpArrow) and if the player is grounded
        if (Input.GetKeyDown(KeyCode.W) && isGrounded && !hasJumped)
        {
            if (doBoing)
            {
                boing.Play();
            }
            Jump();
            hasJumped = true;
        }

        // Apply enhanced gravity when falling or during low jump
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.UpArrow))
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
