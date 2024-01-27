using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class RandomTextButton : MonoBehaviour
{
    public Button myButton;
    private TextMeshProUGUI buttonText;
    private List<string> texts = new List<string> { "Text 1", "Text 2", "Text 3", "Text 4", "Text 5" };

    public Animator animator; // Assign your animator in the inspector

    void Start()
    {
        if (myButton == null)
        {
            Debug.LogError("Button not assigned!");
            return;
        }

        buttonText = myButton.GetComponentInChildren<TextMeshProUGUI>();

        if (buttonText == null)
        {
            Debug.LogError("No TextMeshProUGUI component found on the button!");
            return;
        }

        myButton.onClick.AddListener(ChangeButtonText);
    }

    void ChangeButtonText()
    {
        string randomText = texts[Random.Range(0, texts.Count)];
        buttonText.text = randomText;

        if (randomText == "Text 5")
        {
            // Check if the animator is assigned
            if (animator != null)
            {
                animator.SetTrigger("EggplantTriggerLeft");
            }
            else
            {
                Debug.LogError("Animator not assigned.");
            }
        }
    }
}
