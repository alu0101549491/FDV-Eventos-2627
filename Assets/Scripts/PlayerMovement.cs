using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float rotationSpeed = 1100f;
    private bool isStealthMode = false;

    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector2 launchVelocity;
    private float launchTimeRemaining;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
    }

    private void Update()
    {
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (movement.sqrMagnitude > 1f) movement.Normalize();
    }

    private void FixedUpdate()
    {
        if (launchTimeRemaining > 0f)
        {
            rb.linearVelocity = launchVelocity;
            launchTimeRemaining -= Time.fixedDeltaTime;
            return;
        }

        if (isStealthMode) rb.linearVelocity = movement * (speed * 0.5f);
        else               rb.linearVelocity = movement * speed;

        if (movement.sqrMagnitude == 0f) return;

        float targetAngle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
        float nextAngle = Mathf.MoveTowardsAngle(
            rb.rotation,
            targetAngle,
            rotationSpeed * Time.fixedDeltaTime);
        rb.MoveRotation(nextAngle);
    }

    public void Launch(Vector2 velocity, float duration)
    {
        launchVelocity = velocity;
        launchTimeRemaining = Mathf.Max(0f, duration);
        rb.linearVelocity = velocity;
    }

    public void SwitchStealthMode()
    {
        isStealthMode = !isStealthMode;
        Debug.Log("Stealth Mode: " + (isStealthMode ? "ON" : "OFF"));
    }
}
