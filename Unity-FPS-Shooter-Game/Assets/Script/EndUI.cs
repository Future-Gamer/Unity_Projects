using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class EndUI : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI redCountText;
    [SerializeField] private TextMeshProUGUI greenCountText;
    [SerializeField] private TextMeshProUGUI blueCountText;
    [SerializeField] private Button playAgainButton;
    [SerializeField] private Button quitButton;

    private void OnEnable()
    {
        // Enable and unlock the cursor for UI interaction
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        // Update the UI every time EndUI is shown
        if (EnemyDestroyCounter.Instance != null)
        {
            redCountText.text = $"Red: {EnemyDestroyCounter.Instance.DestroyedRed}";
            greenCountText.text = $"Green: {EnemyDestroyCounter.Instance.DestroyedGreen}";
            blueCountText.text = $"Blue: {EnemyDestroyCounter.Instance.DestroyedBlue}";
        }
    }



    private void Start()
    {
        playAgainButton.onClick.AddListener(OnPlayAgain);
        quitButton.onClick.AddListener(OnQuit);
    }

    private void OnPlayAgain()
    {
        // Reset enemy counts before restarting
        if (EnemyDestroyCounter.Instance != null)
        {
            EnemyDestroyCounter.Instance.ResetCounts();
        }
        SceneManager.LoadScene("GameScene");
    }

    private void OnQuit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
