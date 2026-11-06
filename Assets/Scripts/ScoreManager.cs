using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class ScoreManager : MonoBehaviour
{
    [SerializeField] 
    private CollectableNotifier collectableNotifier;
    TMP_Text scoreText;
    float score = 0f;

    void Start()
    {
        scoreText = GetComponent<TMP_Text>();
        scoreText.text = "Score: " + score.ToString("F0");

        collectableNotifier.OnScoreChanged.AddListener(ChangeScore);
    }

    public void ChangeScore()
    {
        score += 1f;
        scoreText.text = "Score: " + score.ToString("F0");
    }
}
