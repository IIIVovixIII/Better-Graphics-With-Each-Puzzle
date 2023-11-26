using UnityEngine;

public class RotateOnCollision : MonoBehaviour
{
    public GameObject objectToRotate; // Assign the object to rotate in the Inspector
    public float boo = 180f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (objectToRotate != null)
            {
                objectToRotate.transform.Rotate(Vector3.forward, boo); // Rotate by 90 degrees around the Z-axis
            }
        }
    }
}
