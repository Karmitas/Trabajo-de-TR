using UnityEngine;

public class EnemyHitboxHealth : MonoBehaviour
{
    [Header("Set")]
    public EnemyHealth health;
    public float multiplierInPercentage = 0;

    private float x;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player Weapon"))
        {
            x = 1 + (multiplierInPercentage / 100f);
            health.Damaged(other.transform, x);
        }
    }
}
