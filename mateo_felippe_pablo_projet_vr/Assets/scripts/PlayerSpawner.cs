using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public Transform defaultSpawnPoint;
    public Transform elevatorSpawnPoint;
    public Transform SS_Spawnpoint;

    private void Start()
    {
        if (SpawnManager.spawnPointName == "Elevator")
        {
            transform.position = elevatorSpawnPoint.position;
            transform.rotation = elevatorSpawnPoint.rotation;
        }
        else if (SpawnManager.spawnPointName == "SS_Spawnpoint")
        {
            transform.position = SS_Spawnpoint.position;
            transform.rotation = SS_Spawnpoint.rotation;
        }
        else
        {
            transform.position = defaultSpawnPoint.position;
            transform.rotation = defaultSpawnPoint.rotation;
        }
    }
}