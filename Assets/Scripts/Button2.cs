using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class RandomTextButton2 : MonoBehaviour
{
    public Button myButton;
    private TextMeshProUGUI buttonText;
    private List<string> texts = new List<string> { "Text 11", "Text 22", "Text 33", "Text 44", "Text 55" };

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

        if (randomText == "Text 11")
        {
            // Check if the animator is assigned
            if (animator != null)
            {
                animator.SetTrigger("EggplantTriggerRight");
            }
            else
            {
                Debug.LogError("Animator not assigned.");
            }
        }
    }
}
