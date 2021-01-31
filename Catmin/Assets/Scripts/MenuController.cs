using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject PausedMenu;
    public GameObject BlackScreen;
    public GameObject GameName;
    public GameObject WonUI;
    public float FadePercent = 0;
    public bool Won = false;
    Color Fade;
    Color txtFade;
    public Image blackScreen;
    public Text Gametxt;
    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(this);
        WonUI.SetActive(false);
        PausedMenu.SetActive(false);
        BlackScreen.SetActive(false);
        MainMenu.SetActive(true);
        GameName.SetActive(true);

        Fade = blackScreen.color;
        txtFade = Gametxt.color;

    }

    // Update is called once per frame
    void Update()
    {
        if (FadePercent >= 500)
        {
            Fade.a -= 0.01f;
            txtFade.a -= 0.01f;
        }
        blackScreen.color = Fade;
        Gametxt.color = txtFade;
        if (Fade.a == 0 && txtFade.a == 0)
        {
            BlackScreen.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Paused();
        }

    }

    public void Paused()
    {
        Time.timeScale = 0;
        PausedMenu.SetActive(true);

    }
    public void Resume()
    {
        Time.timeScale = 1;
        PausedMenu.SetActive(false);
    }
    public void OnPlay()
    {
        MainMenu.SetActive(false);
        BlackScreen.SetActive(true);
        GameName.SetActive(false);
        Cursor.visible = false;
        StartCoroutine(LoadGameScene());
    }
    public void HasWon()
    {
        WonUI.SetActive(true);
        Cursor.visible = true;
        Time.timeScale = 0;
    }



    public void OnQuit()
    {
        Application.Quit();
    }

    private IEnumerator LoadGameScene()
    {

        SceneManager.LoadScene("GameScene");
        yield return new WaitForSeconds(3f);
    }
    private IEnumerator LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");

        yield return new WaitForSeconds(3f);
    }
}