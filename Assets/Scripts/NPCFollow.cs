using UnityEngine;

public class NPCFollow : MonoBehaviour
{
    [SerializeField]
    private KnifeNotifier notifier;
    [SerializeField]
    private Transform playerTransform;
    [SerializeField]
    private float speed = 2f;
    [SerializeField]
    private float rotationSpeed = 360f;
    private Rigidbody2D rb;
    private bool isFollowing = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        notifier.OnKnifeCollected.AddListener(FollowPlayer);
    }

    void FixedUpdate()
    {
        if (!isFollowing) return;

        Vector2 direction = ((Vector2)playerTransform.position - rb.position).normalized;
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);

        if (direction.sqrMagnitude == 0f) return;

        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        float nextAngle = Mathf.MoveTowardsAngle(
            rb.rotation,
            targetAngle,
            rotationSpeed * Time.fixedDeltaTime);
        rb.MoveRotation(nextAngle);
    }

    private void FollowPlayer()
    {
        isFollowing = true;
    }
}
