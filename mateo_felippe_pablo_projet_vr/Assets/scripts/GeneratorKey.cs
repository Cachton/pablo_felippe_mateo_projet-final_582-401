using UnityEngine;

public class GeneratorKey : MonoBehaviour
{
    public string keyID = "Key_01";

    private bool isPlaced = false;

    public void PlaceInSlot(Transform slotPoint)
    {
        if (isPlaced) return;

        isPlaced = true;

        // Move key to the exact slot position
        transform.position = slotPoint.position;
        transform.rotation = slotPoint.rotation;

        // Lock it there
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
            rb.useGravity = false;
        }

        Collider col = GetComponent<Collider>();
        if (col != null)
        {
            col.enabled = false;
        }

        // Parent it to the slot so it stays attached
        transform.SetParent(slotPoint);
    }
}