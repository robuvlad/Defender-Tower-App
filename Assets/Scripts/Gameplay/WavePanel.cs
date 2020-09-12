using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WavePanel : MonoBehaviour
{
   

    private AudioSource audioWaveChanged = null;

    void Start()
    {
        audioWaveChanged = GetComponent<AudioSource>() as AudioSource;
    }

    private void PlayAudio()
    {
        if (audioWaveChanged != null)
        {
            audioWaveChanged.Play();
        }
    }
}
