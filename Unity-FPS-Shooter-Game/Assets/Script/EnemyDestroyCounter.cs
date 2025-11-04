using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyDestroyCounter : MonoBehaviour
{
    public static EnemyDestroyCounter Instance { get; private set; }

    public int DestroyedRed { get; private set; }
    public int DestroyedGreen { get; private set; }
    public int DestroyedBlue { get; private set; }

    public event System.Action OnGameOver;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // This line is crucial!
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddDestroyed(string color)
    {
        switch (color)
        {
            case "Red": DestroyedRed++; break;
            case "Green": DestroyedGreen++; break;
            case "Blue": DestroyedBlue++; break;
        }
        //CheckObjectiveComplete();
    }

    public void ResetCounts()
    {
        DestroyedRed = 0;
        DestroyedGreen = 0;
        DestroyedBlue = 0;
    }

    public void TriggerGameOver()
    {
        OnGameOver?.Invoke();
    }

    //private void CheckObjectiveComplete()
    //{
    //    // Change these numbers if your objectives change
    //    if (DestroyedRed >= 60 && DestroyedGreen >= 40 && DestroyedBlue >= 20)
    //    {
    //        TriggerGameOver();
    //        //SceneManager.LoadScene("EndUI");
    //    }
    //}
}
