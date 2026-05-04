using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTouchTrigger : MonoBehaviour
{
    public DoorLock doorLock; // Reference to your lock script logic
    public string sceneToLoad;
    public GameObject loadingScreenUI; // Reference to your loading Canvas

    private void OnTriggerEnter(Collider other)
    {
        // 1. Check if the door is actually unlocked
        if (doorLock != null && !doorLock.isLocked)
        {
            // 2. Check if the object touching the door is a controller
            if (other.CompareTag("GameController")) 
            {
                LoadNextLevel();
            }
        }
    }

    private void LoadNextLevel()
    {
        // Show the loading UI to the player
        if (loadingScreenUI != null) loadingScreenUI.SetActive(true);

        // Load the scene
        SceneManager.LoadScene(sceneToLoad);
    }
}