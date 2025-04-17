using UnityEngine;
using UnityEngine.SceneManagement;

public class UiMenuPrincipal : MonoBehaviour
{
    
    
    
    public void RetryLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
