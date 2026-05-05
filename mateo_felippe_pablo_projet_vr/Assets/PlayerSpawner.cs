using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public Transform defaultSpawnPoint;
    public Transform elevatorSpawnPoint;

    private void Start()
    {
        if (SpawnManager.spawnPointName == "Elevator")
        {
            transform.position = elevatorSpawnPoint.position;
            transform.rotation = elevatorSpawnPoint.rotation;
        }
        else
        {
            transform.position = defaultSpawnPoint.position;
            transform.rotation = defaultSpawnPoint.rotation;
        }
    }
}