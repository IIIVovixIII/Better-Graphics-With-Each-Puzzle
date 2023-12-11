using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMoveDown : MonoBehaviour
{
    public float moveSpeed = 15.0f;
    public float moveDistance = 10.0f; // Adjust this to control how far it moves
    public GameObject wall;
    private bool movingDown;
    public AudioSource StoneMove;
    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = wall.transform.position;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with a GameObject tagged "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("hi");
            movingDown = true;
        }
    }

    void Update()
    {
        if (movingDown)
        {
            // Move the wall down
            wall.transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
            if (!StoneMove.isPlaying)
            {
                StoneMove.Play();
            }

            // Check if the wall has moved the desired distance
            if (Vector3.Distance(initialPosition, wall.transform.position) >= moveDistance)
            {
                movingDown = false;
                StoneMove.Stop(); // Stop the sound when movement ends
            }
        }
    }
}
