using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTouchTriggerSsRdc : MonoBehaviour
{
    public string sceneToLoad = "";
    public string spawnPointToUse = "";
    public GameObject loadingScreenUI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GameController"))
        {
            LoadNextLevelSsRdc();
        }
    }

    private void LoadNextLevelSsRdc()
    {

        if (loadingScreenUI != null) loadingScreenUI.SetActive(true);

        SpawnManager.spawnPointName = spawnPointToUse;

        SceneManager.LoadScene(sceneToLoad);
    }
}