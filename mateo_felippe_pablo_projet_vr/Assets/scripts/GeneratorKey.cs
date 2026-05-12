using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GeneratorKey : MonoBehaviour
{
    public string keyID = "Key_01";

    private bool isPlaced = false;

    public void PlaceInSlot(Transform slotPoint)
    {
        if (isPlaced) return;

        isPlaced = true;

        XRGrabInteractable grab = GetComponent<XRGrabInteractable>();
        if (grab != null)
        {
            grab.enabled = false;
        }

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.useGravity = false;
            rb.isKinematic = true;
        }

        Collider[] colliders = GetComponentsInChildren<Collider>();
        foreach (Collider col in colliders)
        {
            col.enabled = false;
        }

        transform.SetParent(slotPoint);
        transform.position = slotPoint.position;
        transform.rotation = slotPoint.rotation;

        Debug.Log(keyID + " locked into place.");
    }
}