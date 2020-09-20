using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] float timeToWait = 0.0f;

    private int sceneIndex;
    private const string SETTINGS_SCENE = "Settings";
    private const string MENU_SCENE = "Menu";
    private const string CREDITS_SCENE = "Credits";
    private const string STORE_SCENE = "Store";
    
    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (sceneIndex == 0)
        {
            StartCoroutine(WaitAndContinue());
        }
    }

    private IEnumerator WaitAndContinue()
    {
        var audio = GetComponent<AudioSource>();
        audio.volume = PlayerPrefsController.GetSoundsPrefs();
        audio.Play();
        //PlayerPrefs.DeleteKey("Level");
        //PlayerPrefs.DeleteKey("Star1");
        //PlayerPrefs.DeleteKey("Star2");
        //PlayerPrefs.DeleteKey("Star3");
        yield return new WaitForSeconds(timeToWait);
        sceneIndex += 1;
        SceneManager.LoadScene(sceneIndex);
    }

    public void PlayLevel(int level)
    {
        SceneManager.LoadScene(level);
        var audio = GetComponent<AudioSource>();
        audio.volume = PlayerPrefsController.GetSoundsPrefs();
        audio.Play();
    }

    public void LoadSettings()
    {
        SceneManager.LoadScene(SETTINGS_SCENE);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(MENU_SCENE);
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene(CREDITS_SCENE);
    }

    public void LoadStore()
    {
        SceneManager.LoadScene(STORE_SCENE);
    }

}
