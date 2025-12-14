using System;
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
    private const string MUTE_KEY = "MuteAll";

    public event Action<float, float, float, bool> OnSettingsChanged;

    public float Master01 { get; private set; } = 1f;
    public float Music01 { get; private set; } = 1f;
    public float Sfx01 { get; private set; } = 1f;
    public bool Muted { get; private set; } = false;

    private float lastMasterBeforeMute = 1f;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if (uiSource != null)
            uiSource.ignoreListenerPause = true;

        LoadInitialSettings();

        if (playMusicOnStart && mainTheme != null)
            PlayMusic(mainTheme);
    }

    public void LoadInitialSettings()
    {
        Master01 = PlayerPrefs.GetFloat(MASTER_VOL_KEY, 1f);
        Music01 = PlayerPrefs.GetFloat(MUSIC_VOL_KEY, 1f);
        Sfx01 = PlayerPrefs.GetFloat(SFX_VOL_KEY, 1f);
        Muted = PlayerPrefs.GetInt(MUTE_KEY, 0) == 1;

        lastMasterBeforeMute = Master01;

        ApplyMixerVolumes(Master01, Music01, Sfx01, Muted);
        OnSettingsChanged?.Invoke(Master01, Music01, Sfx01, Muted);
    }

    public void ApplySettings(float master01, float music01, float sfx01, bool muted, bool savePrefs)
    {
        master01 = Mathf.Clamp01(master01);
        music01 = Mathf.Clamp01(music01);
        sfx01 = Mathf.Clamp01(sfx01);

        if (!muted)
            lastMasterBeforeMute = master01;

        Master01 = master01;
        Music01 = music01;
        Sfx01 = sfx01;
        Muted = muted;

        ApplyMixerVolumes(Master01, Music01, Sfx01, Muted);

        if (savePrefs)
        {
            PlayerPrefs.SetFloat(MASTER_VOL_KEY, Master01);
            PlayerPrefs.SetFloat(MUSIC_VOL_KEY, Music01);
            PlayerPrefs.SetFloat(SFX_VOL_KEY, Sfx01);
            PlayerPrefs.SetInt(MUTE_KEY, Muted ? 1 : 0);
            PlayerPrefs.Save();
        }

        OnSettingsChanged?.Invoke(Master01, Music01, Sfx01, Muted);
    }

    public void SetMasterVolume(float sliderValue) => ApplySettings(sliderValue, Music01, Sfx01, Muted, true);
    public void SetMusicVolume(float sliderValue) => ApplySettings(Master01, sliderValue, Sfx01, Muted, true);
    public void SetSFXVolume(float sliderValue) => ApplySettings(Master01, Music01, sliderValue, Muted, true);

    public void SetMuteAll(bool muted)
    {
        if (!muted)
        {
            ApplySettings(lastMasterBeforeMute, Music01, Sfx01, false, true);
        }
        else
        {
            ApplySettings(Master01, Music01, Sfx01, true, true);
        }
    }

    public void SetMasterVolumeDb(float db)
    {
        if (mainMixer == null) return;
        mainMixer.SetFloat("MasterVolume", db);
    }

    private void ApplyMixerVolumes(float master01, float music01, float sfx01, bool muted)
    {
        if (mainMixer == null) return;

        if (muted)
        {
            mainMixer.SetFloat("MasterVolume", -80f);
            mainMixer.SetFloat("MusicVolume", Linear01ToDb(music01));
            mainMixer.SetFloat("SFXVolume", Linear01ToDb(sfx01));
            return;
        }

        mainMixer.SetFloat("MasterVolume", Linear01ToDb(master01));
        mainMixer.SetFloat("MusicVolume", Linear01ToDb(music01));
        mainMixer.SetFloat("SFXVolume", Linear01ToDb(sfx01));
    }

    private float Linear01ToDb(float v)
    {
        return Mathf.Log10(Mathf.Max(v, 0.0001f)) * 20f;
    }

    public void PlayMusic(AudioClip clip)
    {
        if (clip == null || musicSource == null) return;
        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.pitch = 1f;
        musicSource.Play();
    }

    public void PlayUISound(AudioClip clip)
    {
        if (clip == null || uiSource == null) return;
        uiSource.pitch = UnityEngine.Random.Range(minPitch, maxPitch);
        uiSource.PlayOneShot(clip);
    }

    public void PlayDefaultClick() => PlayUISound(defaultClickClip);
    public void PlayDefaultHover() => PlayUISound(defaultHoverClip);
}