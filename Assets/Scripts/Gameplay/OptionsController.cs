using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider = null;

    void Start()
    {
        volumeSlider.value = PlayerPrefsController.GetVolumePrefs();
    }

    void Update()
    {
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        if (musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);
            PlayerPrefsController.SetVolumePrefs(volumeSlider.value);
        }
    }
}
