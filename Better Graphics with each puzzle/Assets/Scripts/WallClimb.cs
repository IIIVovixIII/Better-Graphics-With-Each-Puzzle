using UnityEngine;

public class WallClimb : MonoBehaviour
{
    public float climbSpeed = 5f;
    private bool isClimbing = false;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("WallClimb script requires a Rigidbody2D component");
        }
    }

    void Update()
    {
        if (isClimbing)
        {
            float inputVertical = Input.GetAxis("Vertical");
            rb.velocity = new Vector2(rb.velocity.x, inputVertical * climbSpeed);
            //transform.rotation = Quaternion.Euler(0, 0, 90); // Rotate the player to 18 degrees

        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {         
        if (other.gameObject.CompareTag("Ground"))
        {
            isClimbing = true;
            rb.gravityScale = 0; // Remove gravity effect while climbing
        }
    }

    private void OnCollisionExit2D(Collision2D other)
{
    if (other.gameObject.CompareTag("Ground"))
    {
        isClimbing = false;
            rb.gravityScale = 1; // Reset gravity scale
        }
    }
}
