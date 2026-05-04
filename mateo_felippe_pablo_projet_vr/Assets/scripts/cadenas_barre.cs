using UnityEngine;

public class DoorLock : MonoBehaviour
{
    public bool isLocked = true;
    public GameObject lockModel; // The physical lock visual to disappear

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("clee_soussol"))
        {
            isLocked = false;
            if (lockModel != null) lockModel.SetActive(false); 
            Destroy(other.gameObject); // Consume the key
            Debug.Log("Door Unlocked!");
        }
    }
}