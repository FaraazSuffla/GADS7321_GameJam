
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        
        SceneManager.LoadScene(1);
    }
    
    public void GoToSettingsMenu()
    {
        SceneManager.LoadScene(2);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
