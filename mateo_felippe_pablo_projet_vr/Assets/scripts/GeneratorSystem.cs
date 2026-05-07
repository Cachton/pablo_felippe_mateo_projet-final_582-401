using UnityEngine;

public class GeneratorSystem : MonoBehaviour
{
    public int requiredKeys = 3;
    public GeneratorLever lever;

    private int insertedKeys = 0;

    private void Start()
    {
        if (lever != null)
        {
            lever.SetLeverUnlocked(false);
        }
    }

    public void KeyInserted()
    {
        insertedKeys++;

        Debug.Log("Generator keys inserted: " + insertedKeys + "/" + requiredKeys);

        if (insertedKeys >= requiredKeys)
        {
            UnlockLever();
        }
    }

    private void UnlockLever()
    {
        Debug.Log("Generator complete. Lever unlocked.");

        if (lever != null)
        {
            lever.SetLeverUnlocked(true);
        }
    }
}