using UnityEngine;

public class GeneratorLever : MonoBehaviour
{
    public Animator leverAnimator;
    public AudioSource leverAudio;

    public string leverTriggerName = "PullLever";

    private bool isUnlocked = false;
    private bool hasBeenPulled = false;

    private void Start()
    {
        if (leverAnimator == null)
        {
            leverAnimator = GetComponent<Animator>();
        }

        if (leverAudio == null)
        {
            leverAudio = GetComponent<AudioSource>();
        }
    }

    public void SetLeverUnlocked(bool unlocked)
    {
        isUnlocked = unlocked;

        Debug.Log("Lever unlocked: " + isUnlocked);
    }

    private void Update()
    {
        if (!isUnlocked) return;
        if (hasBeenPulled) return;

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
                    PullLever();
                }
            }
        }
    }

    public void PullLever()
    {
        if (!isUnlocked) return;
        if (hasBeenPulled) return;

        hasBeenPulled = true;

        if (leverAudio != null)
        {
            leverAudio.Play();
        }

        if (leverAnimator != null)
        {
            leverAnimator.SetTrigger(leverTriggerName);
        }

        Debug.Log("Lever pulled.");
    }
}