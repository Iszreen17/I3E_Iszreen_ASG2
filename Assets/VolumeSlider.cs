using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public Slider volumeSlider;

    void Start()
    {
        volumeSlider.onValueChanged.AddListener(HandleVolumeChange);

        // Load saved volume or default to 1
        float savedVolume = PlayerPrefs.GetFloat("BGMVolume", 1f);
        volumeSlider.value = savedVolume;
        AudioManager.Instance.SetBGMVolume(savedVolume);
    }

    void HandleVolumeChange(float value)
    {
        AudioManager.Instance.SetBGMVolume(value);
        PlayerPrefs.SetFloat("BGMVolume", value);
    }
}
