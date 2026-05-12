using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LightsOnButton : MonoBehaviour
{
    public XRBaseInteractable interactable;

    private bool hasPressed = false;

    private void Start()
    {
        if (interactable == null)
        {
            interactable = GetComponent<XRBaseInteractable>();
        }

        if (interactable != null)
        {
            interactable.selectEntered.AddListener(OnButtonPressed);
        }
    }

    private void OnDestroy()
    {
        if (interactable != null)
        {
            interactable.selectEntered.RemoveListener(OnButtonPressed);
        }
    }

    private void OnButtonPressed(SelectEnterEventArgs args)
    {
        TurnLightsBackOn();
    }

    public void TurnLightsBackOn()
    {
        if (hasPressed) return;

        hasPressed = true;

        GlobalLightState.lightsAreOn = true;

        Debug.Log("Lights will be on when returning to the scene.");
    }
}