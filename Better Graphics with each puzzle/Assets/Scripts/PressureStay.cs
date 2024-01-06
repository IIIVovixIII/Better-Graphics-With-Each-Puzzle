using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureStay : MonoBehaviour
{
    public GameObject objectToDeactivate;
    public GameObject objectToActivate;

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with a GameObject tagged  "Player"
        if (collision.gameObject.CompareTag("Player"))
        {

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
        // Check if the collision is with a GameObject tagged  "Player"
        if (collision.gameObject.CompareTag("Player"))
        {

            // Deactivate the specified GameObject
            if (objectToDeactivate != null)
            {
                objectToDeactivate.SetActive(true);
            }

            // Activate the specified GameObject
            if (objectToActivate != null)
            {
                objectToActivate.SetActive(false);
            }
        }
    }
}
