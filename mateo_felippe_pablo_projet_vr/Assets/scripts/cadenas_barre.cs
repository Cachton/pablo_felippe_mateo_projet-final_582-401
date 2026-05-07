using UnityEngine;

public class DoorLock : MonoBehaviour
{
    public string doorID = "soussol_door_01";

    public bool isLocked = true;
    public GameObject lockModel; // The physical lock visual to disappear

    private void Start()
    {
        if (DoorStateManager.IsDoorUnlocked(doorID))
        {
            UnlockDoorVisualOnly();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("clee_soussol"))
        {
            UnlockDoor();

            Destroy(other.gameObject); // Consume the key

            Debug.Log("Door Unlocked!");
        }
    }

    public void UnlockDoor()
    {
        isLocked = false;

        DoorStateManager.UnlockDoor(doorID);

        if (lockModel != null)
        {
            lockModel.SetActive(false);
        }
    }

    private void UnlockDoorVisualOnly()
    {
        isLocked = false;

        if (lockModel != null)
        {
            lockModel.SetActive(false);
        }
    }
}