using UnityEngine;

public class GeneratorSystem : MonoBehaviour
{
    public int requiredKeys = 3;
    public GeneratorPowerButton powerButton;

    private int insertedKeys = 0;

    private void Start()
    {
        if (powerButton != null)
        {
            powerButton.SetButtonUnlocked(false);
        }
        else
        {
            Debug.LogWarning("No power button assigned to GeneratorSystem.");
        }
    }

    public void KeyInserted()
    {
        insertedKeys++;

        Debug.Log("Generator keys inserted: " + insertedKeys + "/" + requiredKeys);

        if (insertedKeys >= requiredKeys)
        {
            UnlockButton();
        }
    }

    private void UnlockButton()
    {
        Debug.Log("Generator complete. Power button unlocked.");

        if (powerButton != null)
        {
            powerButton.SetButtonUnlocked(true);
        }
    }
}