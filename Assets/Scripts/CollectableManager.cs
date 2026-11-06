using UnityEngine;

public class CollectableManager : MonoBehaviour
{
    [SerializeField]
    private CollectableNotifier collectableNotifier;

    void Start()
    {
        collectableNotifier.OnCollected.AddListener(OnCollected);
    }

    public void OnCollected(string collectableName)
    {
        if (collectableName == gameObject.name)
        {
            Destroy(gameObject);
        }
    }
}
