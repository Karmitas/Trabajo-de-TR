using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [Header("Parameters")]
    public float maxHealth = 100.0f; // Maximum health of the player
    public float currentHealth; // Current health of the player
    public float healthRegenRate = 1.0f; // Rate at which health regenerates per second

    [Space]
    public float damageCooldown = 1.0f; // Cooldown time between taking damage
    private float damageCooldownTimer; // Timer to track damage cooldown

    [Header("Feedback")]
    public Animator anim;

    void Update()
    {
        if (currentHealth < maxHealth)
        {
            // Regenerate health over time
            currentHealth += healthRegenRate * Time.deltaTime;
            currentHealth = Mathf.Min(currentHealth, maxHealth); // Ensure health does not exceed maxHealth
        }

        if (currentHealth >= maxHealth)
        {             
            currentHealth = maxHealth;
        }

        if (damageCooldownTimer > 0)
        {
            damageCooldownTimer -= Time.deltaTime; // Decrease cooldown timer
        }
        else
        {
            damageCooldownTimer = 0; // Reset cooldown timer if it goes below zero
        }
    }

    public void TakeDamage(float x)
    {
        if (damageCooldownTimer <= 0)
        {
            currentHealth -= x; // Reduce current health by damage amount
            damageCooldownTimer = damageCooldown; // Reset cooldown timer
            anim.SetTrigger("Hurt"); // Trigger hurt animation
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Damage"))
        {
            TakeDamage(other.GetComponent<Damage>().damageAmount);
        }
    }
}
