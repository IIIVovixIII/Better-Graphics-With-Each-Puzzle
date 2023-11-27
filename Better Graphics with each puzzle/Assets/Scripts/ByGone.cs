using UnityEngine;

public class ByGone : MonoBehaviour
{
    public GameObject objectToActivate;
    public float activationDuration = 10f;

    private bool isActivated = false;
    private float activationTime;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isActivated)
        {
            isActivated = true;
            objectToActivate.SetActive(true);
            activationTime = Time.time;
        }
    }

    private void Update()
    {
        if (isActivated && Time.time - activationTime >= activationDuration)
        {
            objectToActivate.SetActive(false);
            isActivated = false;
        }
    }
}
