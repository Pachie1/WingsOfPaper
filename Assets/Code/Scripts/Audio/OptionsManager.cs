using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    [Header("UI Component References")]
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    [SerializeField] private Toggle muteAllToggle;

    private const string MASTER_VOL_KEY = "MasterVolume";
    private const string MUSIC_VOL_KEY = "MusicVolume";
    private const string SFX_VOL_KEY = "SFXVolume";
    private const string MUTE_KEY = "MuteAll";

    private bool isInitialized = false;

    private float masterSliderValueFloat;

    private void OnEnable()
    {
        if (AudioManager.Instance != null)
        {
            Debug.Log("Encontre audio");
            LoadSettings();
        }
    }

    private void Start()
    {
        if (!isInitialized)
        {
            InitializeListeners();
            isInitialized = true;
        }
        masterSlider.value = PlayerPrefs.GetFloat(MASTER_VOL_KEY, 1f);
    }

    private void Update()
    {
        masterSliderValueFloat = masterSlider.value;
        PlayerPrefs.SetFloat(MASTER_VOL_KEY,masterSliderValueFloat);
    }
    private void InitializeListeners()
    {
        if (masterSlider != null) masterSlider.onValueChanged.AddListener(AudioManager.Instance.SetMasterVolume);
        if (musicSlider != null) musicSlider.onValueChanged.AddListener(AudioManager.Instance.SetMusicVolume);
        if (sfxSlider != null) sfxSlider.onValueChanged.AddListener(AudioManager.Instance.SetSFXVolume);
        if (muteAllToggle != null) muteAllToggle.onValueChanged.AddListener(SetMuteAll);
    }

    public void SetMuteAll(bool isMuted)
    {
        if (AudioManager.Instance == null || AudioManager.Instance.mainMixer == null) return;

        if (isMuted)
        {
            AudioManager.Instance.mainMixer.SetFloat("MasterVolume", -80f);
        }
        else
        {
            //AudioManager.Instance.SetMasterVolume(masterSlider.value);


            masterSlider.value = PlayerPrefs.GetFloat(MASTER_VOL_KEY, 1f);
        }

        SaveVolumeSettings();
    }

    private void LoadSettings()
    {
        float masterVol = PlayerPrefs.GetFloat(MASTER_VOL_KEY, 1f);
        float musicVol = PlayerPrefs.GetFloat(MUSIC_VOL_KEY, 1f);
        float sfxVol = PlayerPrefs.GetFloat(SFX_VOL_KEY, 1f);
        int isMutedInt = PlayerPrefs.GetInt(MUTE_KEY, 0);

        if (masterSlider != null) masterSlider.value = masterVol;
        if (musicSlider != null) musicSlider.value = musicVol;
        if (sfxSlider != null) sfxSlider.value = sfxVol;
        if (muteAllToggle != null) muteAllToggle.isOn = (isMutedInt == 1);
    }

    public void SaveVolumeSettings()
    {
        if (masterSlider != null) PlayerPrefs.SetFloat(MASTER_VOL_KEY, masterSlider.value);
        if (musicSlider != null) PlayerPrefs.SetFloat(MUSIC_VOL_KEY, musicSlider.value);
        if (sfxSlider != null) PlayerPrefs.SetFloat(SFX_VOL_KEY, sfxSlider.value);

        if (muteAllToggle != null) PlayerPrefs.SetInt(MUTE_KEY, muteAllToggle.isOn ? 1 : 0);

        PlayerPrefs.Save();
    }

    public void OnBackButtonClicked()
    {
        SaveVolumeSettings();
    }
}