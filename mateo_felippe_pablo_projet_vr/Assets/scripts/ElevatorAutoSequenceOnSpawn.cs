using System.Collections;
using UnityEngine;

public class ElevatorAutoSequenceOnSpawn : MonoBehaviour
{
    public Animator porteGAnimator;
    public Animator porteDAnimator;
    public Animator grilleGAnimator;
    public Animator grilleDAnimator;

    public AudioSource openAudioSource;
    public AudioSource closeAudioSource;

    public string openTriggerName = "OpenElevator";
    public string closeTriggerName = "CloseElevator";

    public float delayBeforeClose = 20f;

    public bool onlyPlayWhenSpawnedFromElevator = true;

    private void Start()
    {
        if (onlyPlayWhenSpawnedFromElevator)
        {
            if (SpawnManager.spawnPointName != "Elevator")
            {
                return;
            }
        }

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
        if (openAudioSource != null)
        {
            openAudioSource.Play();
        }

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
        if (closeAudioSource != null)
        {
            closeAudioSource.Play();
        }

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