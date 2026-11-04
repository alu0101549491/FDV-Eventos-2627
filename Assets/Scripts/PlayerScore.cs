using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private int points = 100;

    public int Points => points;

    public void LosePoints(int amount)
    {
        if (amount <= 0)
        {
            return;
        }

        points = Mathf.Max(0, points - amount);
        Debug.Log($"Player points: {points}");
    }
}
