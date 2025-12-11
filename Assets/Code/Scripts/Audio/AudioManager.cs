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
        LoadVolumePreferences();
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
    public void SetMusicVolume(float sliderValue)
    {
        float dB = Mathf.Log10(Mathf.Max(sliderValue, 0.0001f)) * 20f;
        mainMixer.SetFloat("MusicVolume", dB);
        PlayerPrefs.SetFloat("MusicVolumePref", sliderValue); 
        PlayerPrefs.Save();
    }

    public void SetSFXVolume(float sliderValue)
    {
        float dB = Mathf.Log10(Mathf.Max(sliderValue, 0.0001f)) * 20f;
        mainMixer.SetFloat("SFXVolume", dB);
        PlayerPrefs.SetFloat("SFXVolumePref", sliderValue);
        PlayerPrefs.Save();
    }
    public void LoadVolumePreferences()
    {
        float musicVol = PlayerPrefs.GetFloat("MusicVolumePref", 1f);
        SetMusicVolume(musicVol);

        float sfxVol = PlayerPrefs.GetFloat("SFXVolumePref", 1f);
        SetSFXVolume(sfxVol);
    }
}