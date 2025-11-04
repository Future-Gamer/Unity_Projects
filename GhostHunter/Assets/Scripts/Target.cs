using UnityEngine;

public class Target : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // Update score
            TargetScoreManager.Instance.AddScore(1);

            // Destroy the target
            Destroy(gameObject);
        }
    }
}
