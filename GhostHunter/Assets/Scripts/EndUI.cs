using UnityEngine;
using UnityEngine.SceneManagement;

public class EndUI : MonoBehaviour
{
    // Called by Play Again button
    public void OnPlayAgainButton()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Called by Quit button
    public void OnQuitButton()
    {
        // Quit the application
        Application.Quit();

        // If running in the editor, stop play mode (for testing)
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
