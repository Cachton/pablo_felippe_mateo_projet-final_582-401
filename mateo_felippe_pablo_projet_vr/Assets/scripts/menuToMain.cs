
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{

    public Animator canvas;

    public void onPress()
    {
        StartCoroutine("LoadLevel");
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
        SceneManager.LoadScene("main_scene");
    }

}