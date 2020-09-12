using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private AudioSource music = null;

    void Start()
    {
        DontDestroyOnLoad(this);
        music = GetComponent<AudioSource>();
        music.volume = PlayerPrefsController.GetVolumePrefs();
    }

    public void SetVolume(float volume)
    {
        music.volume = volume;
    }
}
