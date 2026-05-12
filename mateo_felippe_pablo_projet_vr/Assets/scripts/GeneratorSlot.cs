using UnityEngine;

public class GeneratorSlot : MonoBehaviour
{
    public string requiredKeyID = "Key_01";
    public Transform snapPoint;
    public GeneratorSystem generatorSystem;

    private bool isFilled = false;

    private void OnTriggerEnter(Collider other)
    {
        TryInsertKey(other);
    }

    private void OnTriggerStay(Collider other)
    {
        TryInsertKey(other);
    }

    private void TryInsertKey(Collider other)
    {
        if (isFilled) return;

        GeneratorKey key = other.GetComponentInParent<GeneratorKey>();

        if (key == null) return;

        if (key.keyID != requiredKeyID) return;

        isFilled = true;

        key.PlaceInSlot(snapPoint);

        if (generatorSystem != null)
        {
            generatorSystem.KeyInserted();
        }

        Debug.Log(requiredKeyID + " inserted into generator slot.");
    }
}