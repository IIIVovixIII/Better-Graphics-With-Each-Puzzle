using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm : MonoBehaviour
{
    // Define the expansion and shrinking speeds
    public float expandSpeed = 2.0f;
    public float shrinkSpeed = 2.0f;

    // Define the maximum and minimum scales
    public Vector3 maxScale = new Vector3(2, 1, 2);
    public Vector3 minScale = new Vector3(1, 1, 1);
    public int reverseLeft = 1; 
    public int reverseRight = 1; 
    public float moveSpeed = 2.0f;
    public float moveDistance = 5.0f; // Adjust this to control how far it moves
    public bool startMovingRight = true;
    
    private bool movingRight;
    private Vector3 initialPosition;

    // State to determine whether the platform is expanding or shrinking
    private bool isExpanding = true;
    private void Start()
    {
        initialPosition = transform.position;
        movingRight = startMovingRight;
    }

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
        // Calculate the distance between the current position and the initial position
        float distance = transform.position.x - initialPosition.x;
  

        // Move the enemy left or right based on the direction
        if(transform.position.x >= reverseLeft)
        {
            movingRight = true;
        }
        else if(transform.position.x <= reverseRight)
        {
            movingRight = false;
        }
        if (movingRight)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }
    }
}
