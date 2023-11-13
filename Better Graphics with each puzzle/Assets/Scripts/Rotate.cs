using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotationSpeed = 50f; // Adjust the speed of rotation as needed

    void Update()
    {
        // Rotate the object around its y-axis
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
