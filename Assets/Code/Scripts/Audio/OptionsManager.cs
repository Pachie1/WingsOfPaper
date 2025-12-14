using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    [Header("UI Component References")]
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Toggle muteAllToggle;

    private bool hooked = false;

    private void OnEnable()
    {
        if (AudioManager.Instance == null) return;

        AudioManager.Instance.OnSettingsChanged += HandleSettingsChanged;

        HandleSettingsChanged(
            AudioManager.Instance.Master01,
            AudioManager.Instance.Music01,
            AudioManager.Instance.Sfx01,
            AudioManager.Instance.Muted
        );

        HookUI();
    }

    private void OnDisable()
    {
        if (AudioManager.Instance != null)
            AudioManager.Instance.OnSettingsChanged -= HandleSettingsChanged;

        UnhookUI();
    }

    private void HookUI()
    {
        if (hooked) return;
        hooked = true;

        if (masterSlider != null) masterSlider.onValueChanged.AddListener(OnMasterChanged);
        if (musicSlider != null) musicSlider.onValueChanged.AddListener(OnMusicChanged);
        if (sfxSlider != null) sfxSlider.onValueChanged.AddListener(OnSfxChanged);
        if (muteAllToggle != null) muteAllToggle.onValueChanged.AddListener(OnMuteChanged);
    }

    private void UnhookUI()
    {
        if (!hooked) return;
        hooked = false;

        if (masterSlider != null) masterSlider.onValueChanged.RemoveListener(OnMasterChanged);
        if (musicSlider != null) musicSlider.onValueChanged.RemoveListener(OnMusicChanged);
        if (sfxSlider != null) sfxSlider.onValueChanged.RemoveListener(OnSfxChanged);
        if (muteAllToggle != null) muteAllToggle.onValueChanged.RemoveListener(OnMuteChanged);
    }

    private void HandleSettingsChanged(float master01, float music01, float sfx01, bool muted)
    {
        if (masterSlider != null) masterSlider.SetValueWithoutNotify(master01);
        if (musicSlider != null) musicSlider.SetValueWithoutNotify(music01);
        if (sfxSlider != null) sfxSlider.SetValueWithoutNotify(sfx01);
        if (muteAllToggle != null) muteAllToggle.SetIsOnWithoutNotify(muted);
    }

    private void OnMasterChanged(float v)
    {
        if (AudioManager.Instance == null) return;
        AudioManager.Instance.ApplySettings(v, AudioManager.Instance.Music01, AudioManager.Instance.Sfx01, AudioManager.Instance.Muted, true);
    }

    private void OnMusicChanged(float v)
    {
        if (AudioManager.Instance == null) return;
        AudioManager.Instance.ApplySettings(AudioManager.Instance.Master01, v, AudioManager.Instance.Sfx01, AudioManager.Instance.Muted, true);
    }

    private void OnSfxChanged(float v)
    {
        if (AudioManager.Instance == null) return;
        AudioManager.Instance.ApplySettings(AudioManager.Instance.Master01, AudioManager.Instance.Music01, v, AudioManager.Instance.Muted, true);
    }

    private void OnMuteChanged(bool muted)
    {
        if (AudioManager.Instance == null) return;
        AudioManager.Instance.SetMuteAll(muted);
    }

    public void OnBackButtonClicked()
    {
        if (AudioManager.Instance == null) return;
        AudioManager.Instance.ApplySettings(
            AudioManager.Instance.Master01,
            AudioManager.Instance.Music01,
            AudioManager.Instance.Sfx01,
            AudioManager.Instance.Muted,
            true
        );
    }
}