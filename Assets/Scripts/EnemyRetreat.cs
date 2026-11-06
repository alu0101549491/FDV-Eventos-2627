using UnityEngine;

public class EnemyRetreat : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isRetreating = false;
    private Transform[] checkpoints;
    [SerializeField]
    private Transform hideoutPoint;
    [SerializeField]
    private GameObject checkpointContainer; 
    [SerializeField]
    private float retreatSpeed = 3f;
    [SerializeField]
    private float rotationSpeed = 360f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        int checkpointCount = checkpointContainer.transform.childCount;
        checkpoints = new Transform[checkpointCount];

        for (int i = 0; i < checkpointCount; i++)
        {
            Transform checkpoint = checkpointContainer.transform.GetChild(i);
            if (checkpoint != null)
            {
                checkpoints[i] = checkpoint;
            }
        }
    }

    private void FixedUpdate()
    {
        if (!isRetreating) return;

        Transform targetPosition = hideoutPoint;
        if (checkpoints.Length > 0)
        {
            targetPosition = checkpoints[0];
        }
        Vector2 direction = (targetPosition.position - transform.position).normalized;

        Rotate(direction);
        rb.MovePosition(rb.position + direction * retreatSpeed * Time.fixedDeltaTime);

        ManageCheckpoints(targetPosition);
    }

    private void Rotate(Vector2 direction)
    {
        if (direction.sqrMagnitude == 0f) return;

        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        float nextAngle = Mathf.MoveTowardsAngle(
            rb.rotation,
            targetAngle,
            rotationSpeed * Time.fixedDeltaTime);
        rb.MoveRotation(nextAngle);
    }

    private void ManageCheckpoints(Transform targetPosition)
    {
        if (Vector2.Distance(transform.position, targetPosition.position) < 0.1f)
        {
            if (checkpoints.Length > 0)
            {
                Transform[] newCheckpoints = new Transform[checkpoints.Length - 1];
                for (int i = 1; i < checkpoints.Length; i++)
                {
                    newCheckpoints[i - 1] = checkpoints[i];
                }
                checkpoints = newCheckpoints;
            }
            else
            {
                isRetreating = false;
                rb.linearVelocity = Vector2.zero;
            }
        }
    }

    public void Retreat()
    {
        isRetreating = true;
    }
}
