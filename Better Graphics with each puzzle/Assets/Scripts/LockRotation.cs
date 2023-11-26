using UnityEngine;

public class LockRotation : MonoBehaviour
{
    public float lockedAngle = 180f; // Angle at which the rotation will be locked

    private Rigidbody2D rb;
    private bool isLocked = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isLocked)
        {
            LockObjectRotation();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isLocked = true;
        }
    }

    private void LockObjectRotation()
    {
        if (rb != null)
        {
            // Freeze the rotation at the specified angle
            rb.MoveRotation(lockedAngle);
        }
    }
}
