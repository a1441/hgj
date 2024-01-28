using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    [SerializeField] public Transform startPoint; // The starting point
    [SerializeField] public Transform controlPoint; // The control point for the arc
    [SerializeField] public Transform endPoint;   // The ending point
    [SerializeField] public float speed = 0.60f;  // Speed of movement
    [SerializeField] public float rotationSpeed = 10.0f; // Speed of rotation (degrees per second)

    private float journeyLength;
    private float startTime;
    private bool isMoving = true;

    // Reference to the character's health script
    [SerializeField] public CharacterHealth characterHealth;

    private void Start()
    {
        // Automatically set the control point if it's not assigned
        if (controlPoint == null)
        {
            Vector3 midPoint = (startPoint.position + endPoint.position) / 2;
            float randomOffset = Random.Range(2, 11); // Get a random number between 1 and 10
            midPoint += new Vector3(0, randomOffset, 0); // Offset the midpoint upwards by a random amount

            // Create a new GameObject for the control point
            GameObject controlPointObj = new GameObject("ControlPoint");
            controlPointObj.transform.position = midPoint;
            controlPoint = controlPointObj.transform;
        }

        journeyLength = Vector3.Distance(startPoint.position, endPoint.position);
        startTime = Time.time;
    }

    private void Update()
    {
        if (isMoving)
        {
            float distanceCovered = (Time.time - startTime) * speed;
            float journeyFraction = distanceCovered / journeyLength;

            // Calculate position on the Bezier curve
            transform.position = CalculateBezierPoint(journeyFraction, startPoint.position, controlPoint.position, endPoint.position);

            // Calculate the rotation amount
            float rotationAmount = rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.back, rotationAmount);

            if (journeyFraction >= 1.0f)
            {
                isMoving = false;
                int randomDamage = Random.Range(1, 21);
                characterHealth.TakeDamage(randomDamage);
                Destroy(gameObject);
            }
        }
    }

    Vector3 CalculateBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {
        // The formula for a quadratic Bezier curve
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;

        Vector3 p = uu * p0; // first term
        p += 2 * u * t * p1; // second term
        p += tt * p2; // third term

        return p;
    }
}
