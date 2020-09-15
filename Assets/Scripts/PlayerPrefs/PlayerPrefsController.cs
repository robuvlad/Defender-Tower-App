using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    private const string VOLUME_KEY = "Volume";
    private const float MIN_VOLUME = 0.0f;
    private const float MAX_VOLUME = 1.0f;

    private const string LEVEL_KEY = "Level";
    private const string SOUNDS_KEY = "Sounds";

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

    public static void SetLevelPrefs(int level)
    {
        if (level >= 0)
        {
            PlayerPrefs.SetInt(LEVEL_KEY, level);
        }
    }

    public static int GetLevelPrefs()
    {
        return PlayerPrefs.GetInt(LEVEL_KEY);
    }

    public static void SetSoundsPrefs(float volumeSounds)
    {
        if (volumeSounds >= MIN_VOLUME && volumeSounds <= MAX_VOLUME)
        {
            PlayerPrefs.SetFloat(SOUNDS_KEY, volumeSounds);
        }
    }

    public static float GetSoundsPrefs()
    {
        return PlayerPrefs.GetFloat(SOUNDS_KEY);
    }
}
