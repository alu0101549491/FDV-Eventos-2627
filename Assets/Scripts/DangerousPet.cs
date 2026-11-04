using UnityEngine;

public class DangerousPet : MonoBehaviour
{
    [SerializeField] private Transform enemy;
    [SerializeField] private Transform target;
    [SerializeField] private Vector2 followOffset = new(0.5f, 0.0f);
    [SerializeField] private float followSpeed = 4f;
    [SerializeField] private float damageDistance = 0.8f;
    [SerializeField] private int damagePoints = 10;
    [SerializeField] private float damageInterval = 1f;

    private float damageCooldown;

    private void Start()
    {
        if (enemy == null && transform.parent != null)
        {
            enemy = transform.parent;
        }

        if (target == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                target = player.transform;
            }
        }

        if (enemy == null || target == null)
        {
            Debug.LogError(
                "DangerousPet needs an enemy parent and a Player-tagged object.",
                this);
        }
    }

    private void Update()
    {
        if (enemy == null || target == null)
        {
            return;
        }

        Vector2 desiredPosition = (Vector2)enemy.position + followOffset;
        transform.position = Vector2.MoveTowards(
            transform.position,
            desiredPosition,
            followSpeed * Time.deltaTime);

        damageCooldown -= Time.deltaTime;
        if (damageCooldown > 0f)
        {
            return;
        }

        if (Vector2.Distance(transform.position, target.position) <= damageDistance)
        {
            PlayerScore score = target.GetComponent<PlayerScore>();
            if (score == null)
            {
                Debug.LogError("The player needs a PlayerScore component.", target);
                return;
            }

            score.LosePoints(damagePoints);
            damageCooldown = damageInterval;
        }
    }
}
