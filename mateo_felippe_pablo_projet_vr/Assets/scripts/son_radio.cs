using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RadioToggleOff : MonoBehaviour
{
    public AudioSource radioAudio;
    public XRBaseInteractable interactable;

    private void Start()
    {
        if (radioAudio == null)
        {
            radioAudio = GetComponent<AudioSource>();
        }

        if (interactable == null)
        {
            interactable = GetComponent<XRBaseInteractable>();
        }

        if (radioAudio != null)
        {
            radioAudio.loop = false; // plays only once
            radioAudio.playOnAwake = true;
        }

        if (interactable != null)
        {
            interactable.selectEntered.AddListener(OnRadioClicked);
        }
        else
        {
            Debug.LogWarning("No XRBaseInteractable found on radio.");
        }
    }

    private void OnDestroy()
    {
        if (interactable != null)
        {
            interactable.selectEntered.RemoveListener(OnRadioClicked);
        }
    }

    private void OnRadioClicked(SelectEnterEventArgs args)
    {
        ToggleRadio();
    }

    private void ToggleRadio()
    {
        if (radioAudio == null) return;

        if (radioAudio.isPlaying)
        {
            radioAudio.Stop();
            Debug.Log("Radio stopped.");
        }
        else
        {
            radioAudio.time = 0f;
            radioAudio.Play();
            Debug.Log("Radio started again.");
        }
    }
}
