using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRGrabInteractable))]
public class TrashSound : MonoBehaviour
{
    public AudioClip pickupSound;

    private XRGrabInteractable grabInteractable;
    private AudioSource audioSource;

    void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();

        // Ajoute automatiquement un AudioSource
        audioSource = gameObject.AddComponent<AudioSource>();

        // Quand on attrape l'objet
        grabInteractable.selectEntered.AddListener(OnGrab);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        if (pickupSound != null)
        {
            audioSource.PlayOneShot(pickupSound);
        }
    }

    private void OnDestroy()
    {
        grabInteractable.selectEntered.RemoveListener(OnGrab);
    }
}