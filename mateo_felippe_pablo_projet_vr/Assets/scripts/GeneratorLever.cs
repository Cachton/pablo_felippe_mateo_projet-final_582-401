using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GeneratorLever : MonoBehaviour
{
    public XRGrabInteractable grabInteractable;
    public AudioSource unlockAudio;

    private bool isUnlocked = false;

    private void Start()
    {
        if (grabInteractable == null)
        {
            grabInteractable = GetComponent<XRGrabInteractable>();
        }

        if (unlockAudio == null)
        {
            unlockAudio = GetComponent<AudioSource>();
        }

        SetLeverUnlocked(false);
    }

    public void SetLeverUnlocked(bool unlocked)
    {
        isUnlocked = unlocked;

        if (grabInteractable != null)
        {
            grabInteractable.enabled = isUnlocked;
        }

        if (isUnlocked && unlockAudio != null)
        {
            unlockAudio.Play();
        }

        Debug.Log("Lever unlocked: " + isUnlocked);
    }
}