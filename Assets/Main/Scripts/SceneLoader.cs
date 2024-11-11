using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class SceneLoader : MonoBehaviour 
{
    [SerializeField] private Button button;
    [SerializeField] private TMP_Text text;
    private int selected_scene = 2;

    public void Start()
    {
        text.text = "Level 1";
    }
    public void ChangeText()
    {
        text.text = $"Level {selected_scene - 1}";
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }

    
    public void LoadLevel()
    {
        SceneManager.LoadScene(selected_scene);
    }

    public void SelectNextLevel()
    {
        if (selected_scene < 11)
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
            selected_scene = 11;

        }

        ChangeText();

    }


}
