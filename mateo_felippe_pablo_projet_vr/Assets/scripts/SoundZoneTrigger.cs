using UnityEngine;

public class SoundZoneTrigger : MonoBehaviour
{
    public AudioSource soundFromObject;
    public bool playOnlyOnce = true;

    private bool hasPlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (playOnlyOnce && hasPlayed) return;

        if (other.CompareTag("GameController"))
        {
            hasPlayed = true;

            if (soundFromObject != null)
            {
                soundFromObject.Play();
            }
            else
            {
                Debug.LogWarning("No AudioSource assigned to SoundZoneTrigger.");
            }
        }
    }
}