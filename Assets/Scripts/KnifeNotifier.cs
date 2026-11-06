using UnityEngine;
using UnityEngine.Events;

public class KnifeNotifier : MonoBehaviour
{
    public UnityEvent OnKnifeCollected;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OnKnifeCollected?.Invoke();
            Destroy(gameObject);
        }
    }
}
