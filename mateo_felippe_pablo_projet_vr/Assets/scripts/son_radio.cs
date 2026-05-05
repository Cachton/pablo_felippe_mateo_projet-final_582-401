using UnityEngine;

public class RadioToggleOff : MonoBehaviour
{
    public AudioSource radioAudio;

    private bool isOff = false;

    private void Start()
    {
        if (radioAudio == null)
        {
            radioAudio = GetComponent<AudioSource>();
        }

        if (radioAudio != null)
        {
            radioAudio.loop = true;
            radioAudio.spatialBlend = 1f; // 3D sound
            radioAudio.Play();
        }
    }

    private void Update()
    {
        if (isOff) return;

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
                    TurnOffRadio();
                }
            }
        }
    }

    private void TurnOffRadio()
    {
        isOff = true;

        if (radioAudio != null)
        {
            radioAudio.Stop();
        }

        Debug.Log("Radio turned off.");
    }
}
