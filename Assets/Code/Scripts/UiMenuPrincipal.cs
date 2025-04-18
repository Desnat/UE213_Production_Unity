using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiMenuPrincipal : MonoBehaviour
{

    public void RetryLevel(string sceneName)
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        SceneManager.LoadScene(sceneName);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void PlayGame ()
    {
	    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
    }
    public void Resume()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        
    }
    public void MainMenu()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
