using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    public void ButtonStart()
    {
        // do fade out
        SceneManager.LoadSceneAsync("GameScene");
    }

    public void ButtonQuit()
    {
        Application.Quit();
    }
}
