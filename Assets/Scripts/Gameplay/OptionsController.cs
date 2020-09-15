using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider musicSlider = null;
    [SerializeField] Slider soundsSlider = null;

    void Start()
    {
        musicSlider.value = PlayerPrefsController.GetVolumePrefs();
        soundsSlider.value = PlayerPrefsController.GetSoundsPrefs();
    }

    void Update()
    {
        UpdateMusic();
        UpdateSounds();
    }

    private void UpdateMusic()
    {
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        if (musicPlayer)
        {
            musicPlayer.SetVolume(musicSlider.value);
            PlayerPrefsController.SetVolumePrefs(musicSlider.value);
        }
    }

    private void UpdateSounds()
    {
        var level = FindObjectOfType<LevelLoader>();
        if (level)
        {
            PlayerPrefsController.SetSoundsPrefs(soundsSlider.value);
        }
    }
}
