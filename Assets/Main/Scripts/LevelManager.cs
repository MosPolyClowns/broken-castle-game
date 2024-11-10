using UnityEngine;
using UnityEngine.SceneManagement;

public static class LevelManager
{
    public static void Restart()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
    }

    public static void Next()
    {
        int index = SceneManager.GetActiveScene().buildIndex + 1;

        if (index >= SceneManager.sceneCountInBuildSettings) index = 0;

        SceneManager.LoadScene(index);
    }
}
