using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public Button yourButton; // Reference to your button in the Inspector.
    public GameObject eggplant; // Reference to your "eggplant" asset in the Inspector.

    void Start()
    {
        // Add a listener to the button's onClick event.
        yourButton.onClick.AddListener(YourButtonClickFunction);
    }

    void YourButtonClickFunction()
    {
        // Check if the "eggplant" asset is not null.
        if (eggplant != null)
        {
            // Activate or perform an action related to the "eggplant" asset.
            eggplant.SetActive(true); // For example, activate the "eggplant" GameObject.
        }
        else
        {
            Debug.LogError("Eggplant asset is not assigned in the Inspector.");
        }
    }
}
