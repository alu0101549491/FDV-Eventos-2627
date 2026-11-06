using UnityEngine;

public class LaunchZone : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float launchForce = 12f;
    [SerializeField] private float launchDuration = 0.5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Rigidbody2D playerBody = other.attachedRigidbody;

        if (playerBody == null || !other.CompareTag("Player"))
        {
            return;
        }

        Debug.Log("Player entered launch zone");
        PlayerMovement playerMovement = playerBody.GetComponent<PlayerMovement>();

        if (playerMovement == null || target == null)
        {
            return;
        }

        Vector2 direction = ((Vector2)target.position - playerBody.position).normalized;
        playerMovement.Launch(direction * launchForce, launchDuration);
    }
}