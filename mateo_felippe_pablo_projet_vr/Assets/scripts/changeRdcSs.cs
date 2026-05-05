using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTouchTrigger : MonoBehaviour
{
    public DoorLock doorLock; 
    public string sceneToLoad;
    public GameObject loadingScreenUI; 

    private void OnTriggerEnter(Collider other)
    {
        if (doorLock != null && !doorLock.isLocked)
        {

            if (other.CompareTag("GameController")) 
            {
                LoadNextLevel();
            }
        }
    }

    private void LoadNextLevel()
    {
        if (loadingScreenUI != null) loadingScreenUI.SetActive(true);

        SceneManager.LoadScene(sceneToLoad);
    }
}