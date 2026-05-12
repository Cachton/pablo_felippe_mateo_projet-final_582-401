using UnityEngine;
using UnityEngine.SceneManagement; 

public class ChangeScenes : MonoBehaviour
{

    public void LoadMain()
    {
        SceneManager.LoadScene("main_scene");
    }

}