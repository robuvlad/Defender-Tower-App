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
        yield return new WaitForSeconds(timeToWait);
        sceneIndex += 1;
        SceneManager.LoadScene(sceneIndex);
    }

    public void PlayLevel(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void LoadSettings()
    {
        SceneManager.LoadScene(SETTINGS_SCENE);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(MENU_SCENE);
    }
}
