using UnityEngine;

public class SceneLightManager : MonoBehaviour
{
    public Light[] lightsToControl;

    private void Start()
    {
        ApplyLightState();
    }

    public void TurnLightsOff()
    {
        GlobalLightState.lightsAreOn = false;
        ApplyLightState();
    }

    public void TurnLightsOn()
    {
        GlobalLightState.lightsAreOn = true;
        ApplyLightState();
    }

    public void ApplyLightState()
    {
        foreach (Light light in lightsToControl)
        {
            if (light != null)
            {
                light.enabled = GlobalLightState.lightsAreOn;
            }
        }
    }
}
