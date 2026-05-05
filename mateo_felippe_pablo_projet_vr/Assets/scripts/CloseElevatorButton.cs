using UnityEngine;

public class CloseElevatorButton : MonoBehaviour
{
    public Animator porteGAnimator;
    public Animator porteDAnimator;
    public Animator grilleGAnimator;
    public Animator grilleDAnimator;

    public AudioSource audioSource;

    public string closeTriggerName = "CloseElevator";

    private bool hasClosed = false;

    private void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    public void CloseElevator()
    {
        Debug.Log("INSIDE BUTTON PRESSED - CloseElevator called");

        if (hasClosed) return;

        hasClosed = true;

        if (audioSource != null)
        {
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("No AudioSource assigned or found on this button.");
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

    private void Update()
    {
        if (hasClosed) return;

        if (Input.GetMouseButtonDown(0))
        {
            Camera cam = Camera.main;

            if (cam == null)
            {
                Debug.LogWarning("No MainCamera found.");
                return;
            }

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, 100f))
            {
                if (hit.collider.transform == transform || hit.collider.transform.IsChildOf(transform))
                {
                    CloseElevator();
                }
            }
        }
    }
}