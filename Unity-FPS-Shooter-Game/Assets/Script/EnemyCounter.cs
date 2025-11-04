using UnityEngine;
using TMPro;

public class EnemyCounterUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI redCountText;
    [SerializeField] private TextMeshProUGUI greenCountText;
    [SerializeField] private TextMeshProUGUI blueCountText;

    void Update()
    {
        if (EnemyDestroyCounter.Instance != null)
        {
            redCountText.text = $"Red: {EnemyDestroyCounter.Instance.DestroyedRed}";
            greenCountText.text = $"Green: {EnemyDestroyCounter.Instance.DestroyedGreen}";
            blueCountText.text = $"Blue: {EnemyDestroyCounter.Instance.DestroyedBlue}";
        }
    }
}
