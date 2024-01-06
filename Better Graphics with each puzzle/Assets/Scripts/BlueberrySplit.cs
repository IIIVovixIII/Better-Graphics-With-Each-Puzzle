using UnityEngine;

public class BlueberrySplit : MonoBehaviour
{
    public GameObject singleBlueberryPrefab1;
    public GameObject singleBlueberryPrefab2;
    public float mergeDelay = 0.5f; // Delay in seconds before they can merge again

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            SplitIntoSingleBlueberries();
        }
    }

    void SplitIntoSingleBlueberries()
    {
        GameObject berry1 = Instantiate(singleBlueberryPrefab1, transform.position + Vector3.right * 0.5f, Quaternion.identity);
        GameObject berry2 = Instantiate(singleBlueberryPrefab2, transform.position + Vector3.left * 0.5f, Quaternion.identity);


        Destroy(gameObject);
    }
}
