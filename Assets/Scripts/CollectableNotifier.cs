using UnityEngine;
using UnityEngine.Events;

public class CollectableNotifier : MonoBehaviour
{
    public UnityEvent<string> OnCollected;
    public UnityEvent OnScoreChanged;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Collectable"))
        {
            OnCollected?.Invoke(other.name);
            OnScoreChanged?.Invoke();
        }
    }
}
