using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class MainMenu : MonoBehaviour
{
    public GameObject menuButtons;
    public GameObject speechBb;
    

    public GameObject leftGroup;
    public GameObject rightGroup;

    public void Start()
    {
        speechBb.SetActive(false);
    }


    public void PlayGame()
    {
       // SceneManager.LoadSceneAsync("scene2");
        menuButtons.gameObject.SetActive(false);
       speechBb.gameObject.SetActive(true);
    }

   public void setText ()
    {
        GameObject child = gameObject.transform.GetChild(0).gameObject;
        TextMeshProUGUI t = child.GetComponent<TextMeshProUGUI>();
        string[] obidi = { "u stoopid", "smelly", "fatso", "garden gnome", "lil goblin", "short", "beak", "fart smella", "smelly socks", "huge nose", "big head", "fat goblin", "chicken legs", "no brain", "ugly", "ugly goblin", "smelly goblin", "fat pig", "fat cow", "ugly pig" };
        int radndomObidaIndex = Random.Range(0, obidi.Length);
        string izbranaObida = obidi[radndomObidaIndex];
        t.text = izbranaObida;

    }
     

    public void QuitGame()

    {
        Application.Quit();
    }

}

