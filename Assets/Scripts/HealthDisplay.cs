using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    private Text healthText;
    private CharacterHealth characterHealth;

    private void Start()
    {
        healthText = GetComponent<Text>();
        characterHealth = FindObjectOfType<CharacterHealth>();

        if (characterHealth == null)
        {
            Debug.LogError("CharacterHealth script not found in the scene.");
        }
    }

    private void Update()
    {
        if (healthText != null && characterHealth != null)
        {
            healthText.text = "Health: " + characterHealth.currentHealth.ToString();
        }
    }
}
