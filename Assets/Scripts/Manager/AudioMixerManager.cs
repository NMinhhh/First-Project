using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioMixerManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider soundSlider;
    [SerializeField] private Slider musicSlider;
    void Start()
    {
        if (PlayerPrefs.HasKey("SoundFX"))
        {
            LoadSoundVolume();
        }
        if (PlayerPrefs.HasKey("Music"))
        {
            LoadMusciVolume();
        }
    }

    public void SetSoundVolume(float value)
    {
        audioMixer.SetFloat("SoundFX",Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("SoundFX", value);
    }

    private void LoadSoundVolume()
    {
        float value = PlayerPrefs.GetFloat("SoundFX");
        soundSlider.value = value;
        audioMixer.SetFloat("SoundFX", Mathf.Log10(value) * 20);
    }

    public void SetMusicVolume(float value)
    {
        audioMixer.SetFloat("Music",Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("Music", value);
    }

    private void LoadMusciVolume()
    {
        float value = PlayerPrefs.GetFloat("Music");
        musicSlider.value = value;
        audioMixer.SetFloat("Music", Mathf.Log10(value) * 20);
    }

}
