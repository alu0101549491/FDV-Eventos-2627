using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField]
    private HealthNotifier healthNotifier;
    private float health, maxHealth;
    private float width = 256f;
    private float height = 50f;

    [SerializeField] 
    private RectTransform healthBar;

    void Start()
    {
        maxHealth = 100f;
        health = maxHealth;
        healthBar.pivot = new Vector2(0f, 0.5f);
        healthBar.sizeDelta = new Vector2(width, height);

        healthNotifier.OnHealthChanged.AddListener(SetHealth);
    }

    public void SetHealth(float phealth)
    {
        health = Mathf.Clamp(health - phealth, 0f, maxHealth);
        float newWidth = (health / maxHealth) * width;

        healthBar.sizeDelta = new Vector2(newWidth, height);
    }
}
