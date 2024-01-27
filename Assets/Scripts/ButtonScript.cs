using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeButtonText : MonoBehaviour
{
    public List<string> phrases = new List<string>()
    {
            "Chicken legs",
            "Square head",
            "Clown shoes",
            "Spaghetti arms",
            "Pencil neck",
            "Jelly belly",
            "Potato face",
            "Tinfoil brain",
            "Slimeball nose",
            "Cabbage brain",
            "Toadstool nose",
            "Bubblegum mouth",
            "Pancake butt",
            "Sausage fingers",
            "Noodle arms",
            "Tater tot",
            "Dorky glasses",
            "Balloon head",
            "Sloth breath",
            "Sock puppet"
    };

    public float fadeDuration = 0.5f; // Duration of the fade effect in seconds

    public Animator eggplantAnimator; // Reference to the eggplant's Animator

    private Button button;
    private CanvasGroup canvasGroup;

    void Start()
    {
        button = GetComponent<Button>();
        canvasGroup = GetComponent<CanvasGroup>();
        TMP_Text textComponent = GetComponentInChildren<TMP_Text>(); // Ensure this is present.

        if (button == null)
        {
            Debug.LogError("Button component not found on the object.");
            return;
        }
        if (textComponent == null)
        {
            Debug.LogError("TMP_Text component not found as a child of the button object.");
            return;
        }
        if (canvasGroup == null)
        {
            Debug.LogError("CanvasGroup component not found on the button object. Please add one.");
            return;
        }

        button.onClick.AddListener(() => StartCoroutine(ChangeTextWithFade()));
        ChangeText(); // Set the initial text from the phrases list.
        canvasGroup.alpha = 1; // Ensure the button is fully visible after setting the text.
    }

    IEnumerator ChangeTextWithFade()
    {
        // Fade out the whole button, change text, fade in the whole button
        yield return FadeOut(canvasGroup, fadeDuration);
        ChangeText();
        yield return FadeIn(canvasGroup, fadeDuration);

        // Check if the new text is "Potato Face" and trigger the eggplant animation
        if (button.GetComponentInChildren<TMP_Text>().text == "Potato face" && eggplantAnimator != null)
        {
            eggplantAnimator.SetTrigger("PlayEggplantAnimation");
        }
    }

    void ChangeText()
    {
        string newPhrase = GetUniqueRandomPhrase();
        TMP_Text textComponent = button.GetComponentInChildren<TMP_Text>();
        if (textComponent != null)
        {
            textComponent.text = newPhrase;
        }
        else
        {
            Debug.LogError("TMP_Text component not found in the button's children.");
        }
    }

    string GetUniqueRandomPhrase()
    {
        if (phrases.Count == 0)
        {
            Debug.Log("No more unique phrases left.");
            return "No more phrases";
        }

        int randomIndex = Random.Range(0, phrases.Count);
        string randomPhrase = phrases[randomIndex];
        phrases.RemoveAt(randomIndex);
        return randomPhrase;
    }

    IEnumerator FadeOut(CanvasGroup canvasGroup, float duration)
    {
        float startAlpha = canvasGroup.alpha;
        for (float t = 0; t < 1; t += Time.deltaTime / duration)
        {
            canvasGroup.alpha = Mathf.Lerp(startAlpha, 0, t);
            yield return null;
        }
        canvasGroup.alpha = 0; // Ensure it ends completely transparent
    }

    IEnumerator FadeIn(CanvasGroup canvasGroup, float duration)
    {
        float startAlpha = canvasGroup.alpha;
        for (float t = 0; t < 1; t += Time.deltaTime / duration)
        {
            canvasGroup.alpha = Mathf.Lerp(startAlpha, 1, t);
            yield return null;
        }
        canvasGroup.alpha = 1; // Ensure it ends fully visible
    }
}
