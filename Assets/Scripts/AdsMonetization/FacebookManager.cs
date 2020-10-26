using UnityEngine;
using Facebook.Unity;
using System.Collections.Generic;

public class FacebookManager : MonoBehaviour
{
    public static FacebookManager Instance;

    void Awake()
    {
        Instance = this;
        if (!FB.IsInitialized)
        {
            // Initialize the Facebook SDK
            FB.Init(InitCallback, OnHideUnity);
        }
        else
        {
            // Already initialized, signal an app activation App Event
            FB.ActivateApp();
        }

        DontDestroyOnLoad(this);
    }

    private void InitCallback()
    {
        if (FB.IsInitialized)
        {
            // Signal an app activation App Event
            FB.ActivateApp();
            // Continue with Facebook SDK
            // ...
        }
        else
        {
            Debug.Log("Failed to Initialize the Facebook SDK");
        }
    }

    private void OnHideUnity(bool isGameShown)
    {
        if (!isGameShown)
        {
            // Pause the game - we will need to hide
            Time.timeScale = 0;
        }
        else
        {
            // Resume the game - we're getting focus again
            Time.timeScale = 1;
        }
    }

    public void LevelEnded(int level)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Level Number"] = level.ToString();

        FB.LogAppEvent(
            "Level Passed",
            parameters: tutParams
        );
    }
}