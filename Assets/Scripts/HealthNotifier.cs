using UnityEngine;
using UnityEngine.Events;

public class HealthNotifier : MonoBehaviour
{
    public UnityEvent<float> OnHealthChanged;
    public float timer = 0f;

    void Update()
    {
        if (timer < 1f) timer += Time.deltaTime;
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DamageSource") && timer >= 1f)
        {
            float damage = 10f; // Example damage value
            OnHealthChanged?.Invoke(damage);
            timer = 0f;
        }
    }
}
