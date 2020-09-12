using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    private const string VOLUME_KEY = "Volume";
    private const float MIN_VOLUME = 0.0f;
    private const float MAX_VOLUME = 1.0f;

    public static void SetVolumePrefs(float volume)
    {
        if (volume >= MIN_VOLUME && volume <= MAX_VOLUME)
        {
            PlayerPrefs.SetFloat(VOLUME_KEY, volume);
        }
    }

    public static float GetVolumePrefs()
    {
        return PlayerPrefs.GetFloat(VOLUME_KEY);
    }
}
