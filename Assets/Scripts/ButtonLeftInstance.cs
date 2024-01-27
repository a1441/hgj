using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class ButtonLeft1 : MonoBehaviour
{
    [SerializeField] public GameObject prefabToSpawn;  // Reference to the prefab to spawn
    [SerializeField] public Transform startPoint;      // Starting point
    [SerializeField] public Transform endPoint;        // Ending point

    [SerializeField] public CharacterHealth characterHealth;

    public Animator characterAnimator;

    private KeywordRecognizer recognizer;
    private ConfidenceLevel confidence = ConfidenceLevel.Low;
    public string obida;

    public void SpawnAndMovePrefab()
    {
        StartCoroutine(doStuff());
    }

    IEnumerator doStuff()
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
        if (obida != "")
        {
            string[] keywords = new string[] {obida};
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
