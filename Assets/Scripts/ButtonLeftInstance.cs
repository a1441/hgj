using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLeft1 : MonoBehaviour
{
    [SerializeField] public GameObject prefabToSpawn;  // Reference to the prefab to spawn
    [SerializeField] public Transform startPoint;      // Starting point
    [SerializeField] public Transform endPoint;        // Ending point

    [SerializeField] public CharacterHealth characterHealth;

    public void SpawnAndMovePrefab()
    {
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
}
