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

    // Reference to the damage sound effect
    public AudioClip damageSound;
    private AudioSource audioSource; // for general sounds
    private AudioSource damageAudioSource; // specifically for damage sound

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

        // Initialize the general audio source
        audioSource = gameObject.AddComponent<AudioSource>();

        // Initialize the damage audio source and calculate volume based on damage
        damageAudioSource = gameObject.AddComponent<AudioSource>();
        float volume = Mathf.Clamp((float)currentHealth / maxHealth, 0.1f, 1.0f) * 0.5f;
        damageAudioSource.volume = volume;
    }

    private void Update()
    {
        UpdateHealthText();
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        // Play damage sound using the dedicated damage audio source
        if (damageSound != null && damageAudioSource != null)
        {
            float volume = Mathf.Clamp((float)currentHealth / maxHealth, 0.1f, 1.0f) * 0.1f;
            damageAudioSource.volume = volume;
            damageAudioSource.PlayOneShot(damageSound);
        }

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
