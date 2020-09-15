using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] float timeToWait = 0.0f;

    private AudioSource music = null;

    void Start()
    {
        DontDestroyOnLoad(this);
        music = GetComponent<AudioSource>();
        music.volume = PlayerPrefsController.GetVolumePrefs();
        StartCoroutine(PlayMusic());
    }

    public void SetVolume(float volume)
    {
        music.volume = volume;
    }

    private IEnumerator PlayMusic()
    {
        yield return new WaitForSeconds(timeToWait);
        music.Play();
    }
}
