using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour 
{
    

    public void Play()
    {
        SceneManager.LoadScene("TestScene");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("GameMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
