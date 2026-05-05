using System.Collections;
using UnityEngine;

public class ElevatorAutoSequence : MonoBehaviour
{
    public Animator porteGAnimator;
    public Animator porteDAnimator;
    public Animator grilleGAnimator;
    public Animator grilleDAnimator;

    public string openTriggerName = "OpenElevator";
    public string closeTriggerName = "CloseElevator";

    public float delayBeforeClose = 45f;

    private void Start()
    {
        StartCoroutine(ElevatorSequence());
    }

    private IEnumerator ElevatorSequence()
    {
        OpenElevator();

        yield return new WaitForSeconds(delayBeforeClose);

        CloseElevator();
    }

    public void OpenElevator()
    {
        if (porteGAnimator != null)
            porteGAnimator.SetTrigger(openTriggerName);

        if (porteDAnimator != null)
            porteDAnimator.SetTrigger(openTriggerName);

        if (grilleGAnimator != null)
            grilleGAnimator.SetTrigger(openTriggerName);

        if (grilleDAnimator != null)
            grilleDAnimator.SetTrigger(openTriggerName);
    }

    public void CloseElevator()
    {
        if (porteGAnimator != null)
            porteGAnimator.SetTrigger(closeTriggerName);

        if (porteDAnimator != null)
            porteDAnimator.SetTrigger(closeTriggerName);

        if (grilleGAnimator != null)
            grilleGAnimator.SetTrigger(closeTriggerName);

        if (grilleDAnimator != null)
            grilleDAnimator.SetTrigger(closeTriggerName);
    }
}