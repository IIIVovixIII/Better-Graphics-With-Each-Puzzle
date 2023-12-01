
using UnityEngine;

public class ExpandShrinkPlatform : MonoBehaviour
{
    // Define the expansion and shrinking speeds
    public float expandSpeed = 2.0f;
    public float shrinkSpeed = 2.0f;

    // Define the maximum and minimum scales
    public Vector3 maxScale = new Vector3(2, 2, 2);
    public Vector3 minScale = new Vector3(1, 1, 1);

    // State to determine whether the platform is expanding or shrinking
    private bool isExpanding = true;

    void Update()
    {
        // Handle the expansion and shrinking logic
        if (isExpanding)
        {
            // Expand the platform
            transform.localScale = Vector3.MoveTowards(transform.localScale, maxScale, expandSpeed * Time.deltaTime);

            // Check if the platform reached its maximum size
            if (transform.localScale == maxScale)
            {
                isExpanding = false;
            }
        }
        else
        {
            // Shrink the platform
            transform.localScale = Vector3.MoveTowards(transform.localScale, minScale, shrinkSpeed * Time.deltaTime);

            // Check if the platform reached its minimum size
            if (transform.localScale == minScale)
            {
                isExpanding = true;
            }
        }
    }
}
