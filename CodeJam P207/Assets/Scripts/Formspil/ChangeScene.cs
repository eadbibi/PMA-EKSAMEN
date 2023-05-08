using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public void LoadAScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName); //This changes the scene depending on the scene number
    }

    public void CloseApplication()
    {
        Application.Quit();
    }
}
