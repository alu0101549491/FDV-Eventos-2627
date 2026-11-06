using UnityEngine;

public class NPCTeleport : MonoBehaviour
{
    [SerializeField]
    private Transform teleportTarget;
    [SerializeField]
    private KnifeNotifier notifier;
    void Start()
    {
        notifier.OnKnifeCollected.AddListener(Teleport);
    }

    void Teleport()
    {
        transform.position = teleportTarget.position;
    }
}
