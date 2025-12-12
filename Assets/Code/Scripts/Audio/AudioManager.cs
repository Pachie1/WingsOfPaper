using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
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
    [SerializeField] private AudioMixer mainMixer;

    [Header("UI Global Clips")]
    [SerializeField] private AudioClip defaultClickClip;
    [SerializeField] private AudioClip defaultHoverClip;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if (playMusicOnStart && mainTheme != null)
        {
            PlayMusic(mainTheme);
        }
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