using UnityEngine;

public class HeadRotation : MonoBehaviour
{
    public Transform target;
    public float rotationSpeed = 5f;

    void LateUpdate()
    {
        if (target == null)
        {
            Debug.Log("Kein Target zugewiesen!");
            return;
        }

        Vector3 direction = target.position - transform.position;
        direction.y = 0f;

        if (direction.sqrMagnitude < 0.001f) return;

        Quaternion targetRotation = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRotation,
            rotationSpeed * Time.deltaTime
        );

        Debug.Log("Kopf dreht sich Richtung Target");
    }
}