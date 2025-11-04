using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float startingTime = 60f; // Start from 60 seconds
    private float currentTime;

    [SerializeField]
    private TextMeshProUGUI countdownText; // Assign in Inspector

    [SerializeField]
    private GameObject EndUI; // Assign your End UI GameObject in Inspector

    [SerializeField]
    private TextMeshProUGUI endUIScoreText; // Assign in Inspector (score text in EndUI)

    [SerializeField]
    private GameObject timerUI; // Assign in Inspector (the timer UI GameObject)

    [SerializeField]
    private GameObject targetDestroyedCounterUI; // Assign in Inspector (the target destroyed counter UI GameObject)

    private bool isGameOver = false;

    void Start()
    {
        currentTime = startingTime;
        UpdateCountdownText();

        // Make sure End UI is hidden at start
        if (EndUI != null)
            EndUI.SetActive(false);
    }

    void Update()
    {
        if (isGameOver)
            return;

        currentTime -= Time.deltaTime;
        if (currentTime < 0)
            currentTime = 0;

        UpdateCountdownText();

        if (currentTime <= 0)
        {
            GameOver();
        }
    }

    void UpdateCountdownText()
    {
        if (countdownText != null)
            countdownText.text = Mathf.CeilToInt(currentTime).ToString();
    }

    void GameOver()
    {
        isGameOver = true;

        // Show the End UI GameObject
        if (EndUI != null)
            EndUI.SetActive(true);

        // Set the score in the End UI
        if (endUIScoreText != null && TargetScoreManager.Instance != null)
            endUIScoreText.text = "Score: " + TargetScoreManager.Instance.GetScore();

        // Disable timer UI
        if (timerUI != null)
            timerUI.SetActive(false);

        // Disable target destroyed counter UI
        if (targetDestroyedCounterUI != null)
            targetDestroyedCounterUI.SetActive(false);
    }
}
