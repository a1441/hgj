using UnityEngine;
using UnityEngine.UI;

public class CharacterHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    // Reference to the UI Text element
    public Text healthText;

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthText(); // Call this method to initialize the UI Text with the current health.
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }

        UpdateHealthText(); // Call this method whenever health changes.
    }
private void Die()
{
    // Access the Animator component
    Animator animator = GetComponent<Animator>();

    if (animator != null)
    {
        // Trigger the "Die" animation
        animator.SetTrigger("die");
    }

    // Implement any other death behavior here.
}

    // Method to update the UI Text with the current health value
    private void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth.ToString();
        }
    }
}
