using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTouchTriggerSsRdc : MonoBehaviour
{
    public string sceneToLoad = "";
    public string spawnPointToUse = "";
    public Animator canvas;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GameController"))
        {
            StartCoroutine("LoadLevel");
        }
    }


    IEnumerator LoadLevel()
    {
        canvas.SetTrigger("start");
        yield return new WaitForSeconds(2f);
        LoadMain();
        yield break;
    }

    public void LoadMain()
    {
        SpawnManager.spawnPointName = spawnPointToUse;
        SceneManager.LoadScene("main_scene");
    }
}