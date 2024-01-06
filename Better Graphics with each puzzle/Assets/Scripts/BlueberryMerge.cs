using UnityEngine;

public class BlueberryMerge : MonoBehaviour
{
    public GameObject doubleBlueberryPrefab; // Assign the double blueberry prefab in the inspector
    private bool isCollidingWithPlayer = false;
    private GameObject player;

    private void Update()
    {
        if (isCollidingWithPlayer && Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("Merging Blueberries");
            Vector3 mergePosition = (transform.position + player.transform.position) / 2;
            Instantiate(doubleBlueberryPrefab, mergePosition, Quaternion.identity);

            // Destroy the single blueberry objects
            Destroy(player);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isCollidingWithPlayer = true;
            player = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isCollidingWithPlayer = false;
            player = null;
        }
    }
}
