using UnityEngine;
using UnityEngine.UI;

public class CharacterHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    // Reference to the UI Text element
    public Text healthText;

    // Reference to the UI Slider for the health bar
    public Slider healthBarSlider;

    private void Start()
    {
        currentHealth = maxHealth;

        // Initialize the health bar slider
        if (healthBarSlider != null)
        {
            healthBarSlider.maxValue = maxHealth;
            healthBarSlider.value = currentHealth;
        }

        UpdateHealthText(); // Initialize the UI Text with the current health
    }

    private void Update()
    {
        UpdateHealthText();
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }

        UpdateHealthText(); // Update UI whenever health changes
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

        // Implement any other death behavior here
    }

    // Method to update the UI Text and the health bar slider
    private void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth.ToString();
        }

        if (healthBarSlider != null)
        {
            healthBarSlider.value = currentHealth;
        }
    }
}
