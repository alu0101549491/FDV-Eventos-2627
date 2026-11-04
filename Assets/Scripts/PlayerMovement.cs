using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float rotationSpeed = 1100f;

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, vertical, 0f);

        if (movement.sqrMagnitude == 0f)
        {
            return;
        }

        movement.Normalize();
        transform.position += movement * speed * Time.deltaTime;

        float targetAngle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, targetAngle);
        transform.rotation = Quaternion.RotateTowards(
            transform.rotation,
            targetRotation,
            rotationSpeed * Time.deltaTime);
    }
}
