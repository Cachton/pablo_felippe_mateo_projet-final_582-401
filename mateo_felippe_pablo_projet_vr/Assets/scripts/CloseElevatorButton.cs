using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CloseElevatorButton : MonoBehaviour
{
    public Animator porteGAnimator;
    public Animator porteDAnimator;
    public Animator grilleGAnimator;
    public Animator grilleDAnimator;

    public AudioSource audioSource;

    public string closeTriggerName = "CloseElevator";

    public string sceneToLoad = "premier_etage_pp";
    public string spawnPointToUse = "";

    public float delayBeforeSceneLoad = 3f;

    private bool isChangingScene = false;

    private void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    public void CloseElevator()
    {
        if (isChangingScene) return;

        isChangingScene = true;

        if (audioSource != null)
        {
            audioSource.Play();
        }

        if (porteGAnimator != null)
            porteGAnimator.SetTrigger(closeTriggerName);

        if (porteDAnimator != null)
            porteDAnimator.SetTrigger(closeTriggerName);

        if (grilleGAnimator != null)
            grilleGAnimator.SetTrigger(closeTriggerName);

        if (grilleDAnimator != null)
            grilleDAnimator.SetTrigger(closeTriggerName);

        StartCoroutine(LoadSceneAfterDelay());
    }

    private IEnumerator LoadSceneAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeSceneLoad);

        SpawnManager.spawnPointName = spawnPointToUse;

        SceneManager.LoadScene(sceneToLoad);
    }

    private void Update()
    {
        if (isChangingScene) return;

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