using UnityEngine;

[DefaultExecutionOrder(-1)]
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance = null;

    [Header("Components")]
    [SerializeField] private AudioSource _SFXAudioSource;
    [SerializeField] private AudioSource _BGMAudioSource;

    [Header("SFX")]
    public AudioClip jumpAudio;
    public AudioClip landAudio;
    public AudioClip runAudio;
    public AudioClip deathAudio;
    public AudioClip winAudio;
    public AudioClip explosionAudio;

    [Header("Backgroundd Music")]
    public AudioClip backgroundMusic;

    private float _gapTimeout = 0.3f;

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

    void Start()
    {
        if (_BGMAudioSource.isPlaying == false)
        {
            _BGMAudioSource.clip = backgroundMusic;
            _BGMAudioSource.Play();
        }
    }

    private void Update()
    {
        _gapTimeout -= Time.deltaTime;
        if (_gapTimeout < 0) _gapTimeout = 0;
    }

    public void PlaySFX(AudioClip _audioClip)
    {
        _SFXAudioSource.clip = _audioClip;
        _SFXAudioSource.Play();
    }

    public void PlayWithGapSFX(AudioClip audioClip, float gap)
    {
        if (_gapTimeout <= 0)
        {
            _SFXAudioSource.clip = audioClip;
            _SFXAudioSource.Play();
            _gapTimeout = gap;
        }
    }

    public void SetSFXPitch(float pitch)
    {
        _SFXAudioSource.pitch = pitch;
    }
}

