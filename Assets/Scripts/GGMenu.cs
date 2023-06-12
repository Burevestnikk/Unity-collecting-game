using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GGMenu : MonoBehaviour
{
    public void GoMenu()
    {
        SceneManager.LoadScene("MenuScene");
        AudioListener.pause = false;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        AudioListener.pause = false;
    }
    public void ExitGameGG()
    {
        Application.Quit();
        AudioListener.pause = false;
    }
}