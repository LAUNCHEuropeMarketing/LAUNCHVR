using UnityEngine;

public class GrretingSound : MonoBehaviour
{
    public AudioSource audioSource;

    private bool hasGreeted = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasGreeted) return;

        if (other.CompareTag("MainCamera"))
        {
            hasGreeted = true;

            if (audioSource != null)
            {
                audioSource.Play();
            }
        }
    }
}