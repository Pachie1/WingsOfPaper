using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [Header("Audio Sources")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioSource uiSource;

    [Header("Pitch randomization")]
    [SerializeField] private float minPitch = 0.95f;
    [SerializeField] private float maxPitch = 1.05f;

    [Header("Music")]
    [SerializeField] private AudioClip mainTheme;
    [SerializeField] private bool playMusicOnStart = true;

    [Header("Audio Mixer")]
    [SerializeField] public AudioMixer mainMixer;

    [Header("UI Global Clips")]
    [SerializeField] private AudioClip defaultClickClip;
    [SerializeField] private AudioClip defaultHoverClip;

    private const string MASTER_VOL_KEY = "MasterVolume";
    private const string MUSIC_VOL_KEY = "MusicVolume";
    private const string SFX_VOL_KEY = "SFXVolume";

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        if (playMusicOnStart && mainTheme != null)
        {
            PlayMusic(mainTheme);
        }

        if (uiSource != null)
        {
            uiSource.ignoreListenerPause = true;
        }

        LoadInitialVolumes();
    }

    public void LoadInitialVolumes()
    {
        float masterVol = PlayerPrefs.GetFloat(MASTER_VOL_KEY, 1f);
        float musicVol = PlayerPrefs.GetFloat(MUSIC_VOL_KEY, 1f);
        float sfxVol = PlayerPrefs.GetFloat(SFX_VOL_KEY, 1f);

        SetMasterVolume(masterVol);
        SetMusicVolume(musicVol);
        SetSFXVolume(sfxVol);
    }

    public void PlayMusic(AudioClip clip)
    {
        if (musicSource == null) return;
        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlayUISound(AudioClip clip)
    {
        if (clip == null || uiSource == null) return;

        uiSource.pitch = Random.Range(minPitch, maxPitch);
        uiSource.PlayOneShot(clip);
    }

    public void PlayDefaultClick()
    {
        PlayUISound(defaultClickClip);
    }

    public void PlayDefaultHover()
    {
        PlayUISound(defaultHoverClip);
    }

    public void SetMasterVolume(float sliderValue)
    {
        float dB = Mathf.Log10(Mathf.Max(sliderValue, 0.0001f)) * 20f;
        mainMixer.SetFloat("MasterVolume", dB);
    }

    public void SetMusicVolume(float sliderValue)
    {
        float dB = Mathf.Log10(Mathf.Max(sliderValue, 0.0001f)) * 20f;
        mainMixer.SetFloat("MusicVolume", dB);
    }

    public void SetSFXVolume(float sliderValue)
    {
        float dB = Mathf.Log10(Mathf.Max(sliderValue, 0.0001f)) * 20f;
        mainMixer.SetFloat("SFXVolume", dB);
    }
}