using UnityEngine;

public class HoverOnLook : MonoBehaviour
{
    [Header("Hover")]
    public float hoverHeight = 0.35f;
    public float moveSpeed = 2.5f;

    [Header("Idle Float")]
    public float floatHeight = 0.008f;
    public float floatSpeed = 1f;

    private Vector3 startPosition;
    private bool isLooking;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Zielposition
        Vector3 target = startPosition;

        if (isLooking)
        {
            target += Vector3.up * hoverHeight;

            // GANZ leichtes Schweben
            target += Vector3.up * (Mathf.Sin(Time.time * floatSpeed) * floatHeight);
        }

        // Butterweiche Bewegung
        transform.position = Vector3.Lerp(
            transform.position,
            target,
            Time.deltaTime * moveSpeed);
    }

    public void SetLooking(bool looking)
    {
        isLooking = looking;
    }
}