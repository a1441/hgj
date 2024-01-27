using UnityEngine;
using UnityEngine.UI;

public class RotateEggplant : MonoBehaviour
{
    public GameObject eggplant; // Drag and drop your eggplant GameObject here
    public Animation animation; // Drag and drop your eggplant's animation here

    public void RotateEggplantOnClick()
    {
        if (animation != null)
        {
            animation.Play("EggplantRotation"); // Replace "EggplantRotation" with your actual animation name
        }
    }
}
