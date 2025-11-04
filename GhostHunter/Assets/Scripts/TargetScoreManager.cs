using UnityEngine;
using TMPro;

public class TargetScoreManager : MonoBehaviour
{
    public static TargetScoreManager Instance { get; private set; }

    [SerializeField]
    private TextMeshProUGUI scoreText; // Assign in Inspector

    private int score = 0;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }


    public int GetScore()
    {
        return score;
    }
}
