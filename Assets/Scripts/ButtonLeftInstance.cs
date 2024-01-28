using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

using TMPro;
public class ButtonLeft1 : MonoBehaviour
{
    private string[] phrases = new string[] {
        "u stoopid", "smelly", "fatso", "garden gnome", "lil goblin", "short", 
        "beak", "fart smella", "smelly socks", "huge nose", "big head", "fat goblin", 
        "chicken legs", "no brain", "ugly", "ugly goblin", "smelly goblin", 
        "fat pig", "fat cow", "ugly pig"
    };
    private GameObject[] prefabOptions;

    [SerializeField] public GameObject chicken;
    [SerializeField] public GameObject fatass; // Reference to the
    [SerializeField] public GameObject grandma;
    [SerializeField] public GameObject pig;
    [SerializeField] public GameObject sock;

    [SerializeField] public GameObject pepe;
    [SerializeField] public GameObject pika;

    [SerializeField] public Transform startPoint;      // Starting point
    [SerializeField] public Transform endPoint;        // Ending point

    [SerializeField] public CharacterHealth characterHealth;

    public Animator characterAnimator;

    private KeywordRecognizer recognizer;
    private ConfidenceLevel confidence = ConfidenceLevel.Low;
    public string obida;

    public void setText()
    {
        // Find the TextMeshProUGUI component in the child GameObject
        TextMeshProUGUI t = gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

        // Your array of phrases
        string[] obidi =  { "u stoopid", "smelly", "fatso", "garden gnome", "lil goblin", "short", "beak", "fart smella", "smelly socks", "huge nose", "big head", "fat goblin", "chicken legs", "no brain", "ugly", "ugly goblin", "smelly goblin", "fat pig", "fat cow", "ugly pig" };

        // Randomly select a phrase
        int randomObidaIndex = Random.Range(0, obidi.Length);
        string izbranaObida = obidi[randomObidaIndex];

        // Set the text of the TextMeshProUGUI component
        t.text = izbranaObida;
        obida = izbranaObida;
    }
    

    public void SpawnAndMovePrefab()
    {
        var prefabToSpawn = prefabOptions[Random.Range(0, prefabOptions.Length)];
        setText();

        StartCoroutine(doStuff(prefabToSpawn));
    }

    IEnumerator doStuff(GameObject prefabToSpawn)
    {
        int[] attackIndices = {1, 3, 4}; // Array of the possible attack indices
        int randomIndex = attackIndices[Random.Range(0, attackIndices.Length)]; // Randomly select an index
        string attackAnimationName = "attack" + randomIndex; // Construct the animation name

        characterAnimator.Play(attackAnimationName); // Play the animation

        yield return new WaitForSeconds(1);
        if (prefabToSpawn != null)
        {
            // Instantiate the prefab
            GameObject spawnedPrefab = Instantiate(prefabToSpawn, startPoint.position, Quaternion.identity);

            // Get the ObjectMover component from the spawned prefab
            ObjectMover mover = spawnedPrefab.GetComponent<ObjectMover>();

            if (mover != null)
            {
                // Set the start and end points for the ObjectMover
                mover.startPoint = startPoint;
                mover.endPoint = endPoint;
                mover.characterHealth = characterHealth;

                // Start moving the prefab
                mover.enabled = true;
            }
        }
    }

   void Start()
    {
        setText();
        // SetRandomText();
        // Initialize the array with your GameObjects
        prefabOptions = new GameObject[] { pika, pepe, chicken, fatass, grandma, pig, sock };

        // Randomly select one of the GameObjects

        if (obida != "")
        {
            string[] keywords = new string[] { obida };
            recognizer = new KeywordRecognizer(keywords, confidence);
            recognizer.OnPhraseRecognized += Recognizer_OnPhraseRecognized;
            recognizer.Start();
        }
        
    }

    private void Recognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        Debug.Log(args.text);
        SpawnAndMovePrefab();
    }
    private void OnApplicationQuit()
    {
        if (recognizer != null && recognizer.IsRunning)
        {
            recognizer.OnPhraseRecognized -= Recognizer_OnPhraseRecognized;
            recognizer.Stop();
        }
    }
}
