using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeMenu : MonoBehaviour
{
    public GameObject escapeMenu;

    public void ShowMenu()
    {
        escapeMenu.SetActive(true);

        Time.timeScale = 0f;

        AudioListener.pause = true;
    }

    public void HideMenu()
    {
        escapeMenu.SetActive(false);

        Time.timeScale = 1f;

        AudioListener.pause = false;
    }

    public void GoMenu()
    {
        SceneManager.LoadScene("MenuScene");
        Time.timeScale = 1f;
        AudioListener.pause = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        AudioListener.pause = false;
    }

    public void ExitGameGG()
    {
        Application.Quit();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (escapeMenu.activeSelf)
            {
                HideMenu();
            }
            else
            {
                ShowMenu();
            }
        }
    }
}
