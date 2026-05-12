using UnityEngine;

public class LightsOffZone : MonoBehaviour
{
    public SceneLightManager lightManager;
    public AudioSource lightsOffAudio;

    private void Start()
    {
        if (lightsOffAudio == null)
        {
            lightsOffAudio = GetComponent<AudioSource>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (GlobalLightState.lightsOffZoneAlreadyTriggered) return;

        if (other.CompareTag("GameController"))
        {
            GlobalLightState.lightsOffZoneAlreadyTriggered = true;

            if (lightsOffAudio != null)
            {
                lightsOffAudio.Play();
            }

            if (lightManager != null)
            {
                lightManager.TurnLightsOff();
            }

            Debug.Log("Lights turned off forever from this zone.");
        }
    }
}
