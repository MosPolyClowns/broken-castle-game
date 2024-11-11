using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(-1)]
public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance = null;

    [SerializeField] private Animator _transitionAnimator;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Restart()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        StartCoroutine(LoadWithTransition(index));
    }

    public void LoadNext()
    {
        int index = SceneManager.GetActiveScene().buildIndex + 1;

        if (index >= SceneManager.sceneCountInBuildSettings) index = 0;

        StartCoroutine(LoadWithTransition(index));
    }

    public void Load(int index)
    {
        StartCoroutine(LoadWithTransition(index));
    }

    private IEnumerator LoadWithTransition(int index)
    {
        if (_transitionAnimator == null)
        {
            _transitionAnimator = FindAnyObjectByType<Canvas>().GetComponentInChildren<Animator>();
        }

        _transitionAnimator.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(index);
    }
}
