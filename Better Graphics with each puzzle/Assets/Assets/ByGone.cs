using UnityEngine;

public class ByGone : MonoBehaviour
{
    public GameObject objectToActivate;
    public GameObject platform; // The platform to shrink
    public float activationDuration = 10f;
    public float shrinkRate = 0.1f; // Rate at which the platform shrinks

    private bool isActivated = false;
    private float activationTime;
    private Vector3 originalScale; // To store the original scale of the platform

    private void Start()
    {
        // Store the original scale of the platform
        originalScale = platform.transform.localScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isActivated)
        {
            isActivated = true;
            objectToActivate.SetActive(true);
            activationTime = Time.time;

            // Reset the scale of the platform in case it's not the first activation
            platform.transform.localScale = originalScale;
        }
    }

    private void Update()
    {
        if (isActivated)
        {
            // Calculate the elapsed time
            float elapsedTime = Time.time - activationTime;

            if (elapsedTime < activationDuration)
            {
                // Shrink the platform gradually
                float scale = 1 - (elapsedTime / activationDuration) * shrinkRate;
                platform.transform.localScale = new Vector3(originalScale.x * scale, originalScale.y, originalScale.z);
            }
            else
            {
                // Time is up, reset everything
                objectToActivate.SetActive(false);
                platform.transform.localScale = originalScale; // Reset the scale of the platform
                isActivated = false;
            }
        }
    }
}
