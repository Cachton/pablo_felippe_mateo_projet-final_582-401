using UnityEngine;

public class GeneratorPowerButton : MonoBehaviour
{
    public AudioSource buttonAudio;
    public GameObject buttonOnVisual;
    public GameObject buttonOffVisual;

    private bool isUnlocked = false;
    private bool hasBeenPressed = false;

    private void Start()
    {
        if (buttonAudio == null)
        {
            buttonAudio = GetComponent<AudioSource>();
        }

        UpdateVisuals();

        Debug.Log("Power button started. Unlocked = " + isUnlocked);
    }

    public void SetButtonUnlocked(bool unlocked)
    {
        isUnlocked = unlocked;

        Debug.Log("POWER BUTTON UNLOCKED STATE CHANGED TO: " + isUnlocked);

        UpdateVisuals();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something touched power button: " + other.name + " | Tag: " + other.tag);

        if (!isUnlocked)
        {
            Debug.Log("Button touched, but it is still locked.");
            return;
        }

        if (hasBeenPressed)
        {
            Debug.Log("Button already pressed.");
            return;
        }

        if (other.CompareTag("GameController"))
        {
            PressButton();
        }
        else
        {
            Debug.Log("Wrong tag. Your controller/hand needs tag GameController.");
        }
    }

    private void PressButton()
    {
        hasBeenPressed = true;

        if (buttonAudio != null)
        {
            buttonAudio.Play();
        }
        else
        {
            Debug.LogWarning("No button audio assigned.");
        }

        GlobalLightState.lightsAreOn = true;

        Debug.Log("GENERATOR POWER BUTTON PRESSED. LIGHTS REACTIVATED.");

        UpdateVisuals();
    }

    private void UpdateVisuals()
    {
        if (buttonOnVisual != null)
        {
            buttonOnVisual.SetActive(isUnlocked && hasBeenPressed);
        }

        if (buttonOffVisual != null)
        {
            buttonOffVisual.SetActive(!hasBeenPressed);
        }
    }
}