using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    // VOLUME
    private const string VOLUME_KEY = "Volume";
    private const float MIN_VOLUME = 0.0f;
    private const float MAX_VOLUME = 1.0f;

    // LEVEL INDEX
    private const string LEVEL_KEY = "Level";
    private const int MIN_LEVEL = 0;

    // ALL SOUNDS except volume
    private const string SOUNDS_KEY = "Sounds";

    // STARS
    private const string STAR_KEY = "Star";
    private const int MAX_PLACE_STAR = 3;
    private const int MIN_PLACE_STAR = 1;

    // BOUGHT DEFENDERS
    private const string BOUGHT_DEF_KEY = "Bought_Defender";

    // SCORE
    private const string SCORE_KEY = "Score";

    // MAX LEVEL
    private const int MAX_LEVEL = 5;

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
        if (level >= MIN_LEVEL)
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

    public static void SetStarPrefs(int currentLevel, int place)
    {
        if (place >= MIN_PLACE_STAR && place <= MAX_PLACE_STAR && currentLevel <= MAX_LEVEL)
        {
            string starLevel = STAR_KEY + currentLevel.ToString();
            int currentPlace = PlayerPrefs.GetInt(starLevel);
            if (currentPlace == 0 || currentPlace > place)
            {
                PlayerPrefs.SetInt(starLevel, place);
            }
        }
    }

    public static int GetStarPrefs(int level)
    {
        string starLevel = STAR_KEY + level.ToString();
        return PlayerPrefs.GetInt(starLevel);
    }

    public static int GetMaxLevel()
    {
        return MAX_LEVEL;
    }

    // isBought must be 0 or 1
    public static void SetBoughDefenderPrefs(int defenderIndex, int isBought)
    {
        if (isBought != 0 && isBought != 1)
            return;
        string key = BOUGHT_DEF_KEY + defenderIndex.ToString();
        PlayerPrefs.SetInt(key, isBought);
    }

    public static int GetBoughtDefenderPrefs(int defenderIndex)
    {
        string key = BOUGHT_DEF_KEY + defenderIndex;
        return PlayerPrefs.GetInt(key);
    }

    public static void SetScorePrefs(int score)
    {
        PlayerPrefs.SetInt(SCORE_KEY, score);
    }

    public static int GetScorePrefs()
    {
        return PlayerPrefs.GetInt(SCORE_KEY);
    }
}
