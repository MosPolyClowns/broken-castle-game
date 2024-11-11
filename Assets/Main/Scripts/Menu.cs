using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Menu : MonoBehaviour 
{
    private LevelManager _levelManager;

    [SerializeField] private Button button;
    [SerializeField] private TMP_Text text;

    private int selected_scene = 2;

    public void Start()
    {
        _levelManager = LevelManager.Instance;
    }
    public void ChangeText()
    {
        text.text = $"Level {selected_scene - 1}";
    }
    public void Play()
    {
        _levelManager.Load(1);
    }

    public void BackToMenu()
    {
        _levelManager.Load(0);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void LoadLevel()
    {
        _levelManager.Load(selected_scene);
    }

    public void SelectNextLevel()
    {
        if (selected_scene < SceneManager.sceneCountInBuildSettings - 1)
        {
            selected_scene++;
            
        }
        else
        {
            selected_scene = 2;
            
        }

        ChangeText();

    }

    public void SelectPrevLevel()
    {
        if (selected_scene > 2)
        {
            selected_scene--;

        }
        else
        {
            selected_scene = SceneManager.sceneCountInBuildSettings - 1;
        }

        ChangeText();

    }


}
