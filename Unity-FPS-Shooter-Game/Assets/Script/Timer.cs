using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement; // Add this

public class Timer : MonoBehaviour
{
    float currentTime;
    public float startingTime = 120f; // Start from 120 Seconds

    [SerializeField]
    TMPro.TextMeshProUGUI countdownText;

    void Start()
    {
        currentTime = startingTime;
    }
    void Update()
    {
        // subtracting time in each frame
        currentTime -= Time.deltaTime;

        if (currentTime < 0)
            currentTime = 0;

        countdownText.text = currentTime.ToString("0"); // Displaying only integer value

        if (currentTime <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over!");
        // Notify other systems that the game is over
        if (EnemyDestroyCounter.Instance != null)
        {
            EnemyDestroyCounter.Instance.TriggerGameOver();
        }
        // If you want to load the EndUI scene directly from here, you can:
        // SceneManager.LoadScene("EndUI");
    }

}
