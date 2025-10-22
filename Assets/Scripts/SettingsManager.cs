using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [Header("Audio")]
    public AudioSource bgmAudioSource;
    public AudioSource sfxAudioSource;

    [Header("Toggles")]
    public Toggle bgmToggle;
    public Toggle sfxToggle;

    private void Start()
    {
        // Load saved settings
        bgmToggle.isOn = PlayerPrefs.GetInt("BGM", 1) == 1;
        sfxToggle.isOn = PlayerPrefs.GetInt("SFX", 1) == 1;

        // Apply settings
        ApplyBGM(bgmToggle.isOn);
        ApplySFX(sfxToggle.isOn);

        // Add listeners
        bgmToggle.onValueChanged.AddListener(ApplyBGM);
        sfxToggle.onValueChanged.AddListener(ApplySFX);
    }

    private void ApplyBGM(bool isOn)
    {
        bgmAudioSource.mute = !isOn;
        PlayerPrefs.SetInt("BGM", isOn ? 1 : 0);
    }

    private void ApplySFX(bool isOn)
    {
        sfxAudioSource.mute = !isOn;
        PlayerPrefs.SetInt("SFX", isOn ? 1 : 0);
    }
}
