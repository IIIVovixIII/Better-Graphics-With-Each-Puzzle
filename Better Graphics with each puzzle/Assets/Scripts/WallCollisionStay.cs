using UnityEngine;

public class WallCollisionStay : MonoBehaviour
{
    public GameObject objectToDeactivate;
    public GameObject objectToActivate;

    void OnCollisionStay2D(Collision2D collision)
    {
        // Check if the collision is with a GameObject tagged "Wall"
        if (collision.gameObject.CompareTag("Pressureball"))
        {
            Debug.Log("HELLO");

            // Deactivate the specified GameObject
            if (objectToDeactivate != null)
            {
                objectToDeactivate.SetActive(false);
            }

            // Activate the specified GameObject
            if (objectToActivate != null)
            {
                objectToActivate.SetActive(true);
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // Check if the collision has ended
        if (collision.gameObject.CompareTag("Pressureball"))
        {
            Debug.Log("BYE");

            // Reactivate the specified GameObject
            if (objectToDeactivate != null)
            {
                objectToDeactivate.SetActive(false);
            }

            // Deactivate the specified GameObject
            if (objectToActivate != null)
            {
                objectToActivate.SetActive(true);
            }
        }
    }
}
