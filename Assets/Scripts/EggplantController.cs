using UnityEngine;

public class EggplantController : MonoBehaviour
{
    private Animator animator;


    private void Start()
    {
        animator = GetComponent<Animator>();
        HideEggplant(); // By default, hide the eggplant when the scene starts
    }

    public void ShowEggplant()
    {
        // Show the eggplant by enabling its renderer and triggering its animation
        if (animator != null)
        {
            animator.SetTrigger("EggplantTrigger"); // Replace with your animation trigger name
        }
        else
        {
            Debug.LogError("Animator component not found on the eggplant.");
        }
    }

    public void HideEggplant()
    {
        // Hide the eggplant by disabling its renderer
        if (animator != null)
        {
            animator.ResetTrigger("YourAnimationTriggerName"); // Reset the animation trigger
        }
        else
        {
            Debug.LogError("Animator component not found on the eggplant.");
        }
    }
}
