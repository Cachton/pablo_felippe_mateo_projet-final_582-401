using UnityEngine;

public class DoorButton : MonoBehaviour
{
    public Animator porteGAnimator;
    public Animator porteDAnimator;
    public Animator grilleGAnimator;
    public Animator grilleDAnimator;

    public AudioSource audioSource;

    public string openTriggerName = "OpenElevator";

    private void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    private void Update()
    {
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
                    OpenElevator();
                }
            }
        }
    }

    public void OpenElevator()
    {
        if (audioSource != null)
        {
            audioSource.Play();
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
}