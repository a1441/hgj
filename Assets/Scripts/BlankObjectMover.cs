using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    [SerializeField] public Transform startPoint; // The starting point
    [SerializeField] public Transform endPoint;   // The ending point
    [SerializeField] public float speed = 1.0f;  // Speed of movement
    [SerializeField] public float rotationSpeed = 90.0f; // Speed of rotation (degrees per second)

    private float journeyLength;
    private float startTime;
    private bool isMoving = true;

    // Reference to the character's health script
    [SerializeField] public CharacterHealth characterHealth;

    private void Start()
    {
        journeyLength = Vector3.Distance(startPoint.position, endPoint.position);
        startTime = Time.time;
    }

    private void Update()
    {
        if (isMoving)
        {
            float distanceCovered = (Time.time - startTime) * speed;
            float journeyFraction = distanceCovered / journeyLength;

            transform.position = Vector3.Lerp(startPoint.position, endPoint.position, journeyFraction);

            // Calculate the rotation amount
            float rotationAmount = rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.back, rotationAmount);

            if (journeyFraction >= 1.0f)
            {
                // The object has reached the end point
                // You can perform any additional actions here
                isMoving = false;

                // Apply random damage to the character's health
                int randomDamage = Random.Range(1, 21); // Random damage between 1 and 20
                characterHealth.TakeDamage(randomDamage);

                Destroy(gameObject); // Destroy the object
            }
        }
    }
}
