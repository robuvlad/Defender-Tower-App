using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour
{
    [Header("Congrats Panel Config")]
    [SerializeField] GameObject nextLevelPanel = null;
    [SerializeField] float duration = 0.4f;

    [Header("Types of stars")]
    [SerializeField] List<GameObject> stars = null;

    void Start()
    {
        nextLevelPanel.SetActive(false);
        foreach(GameObject star in stars)
        {
            star.SetActive(false);
        }
    }

    public void ShowPanel()
    {
        nextLevelPanel.SetActive(true);
        ActivateFading();
        PlayAudio();
        ShowStars();
        SetLevelPrefs();
    }

    private void ActivateFading()
    {
        var canvasGroup = nextLevelPanel.GetComponent<CanvasGroup>();
        StartCoroutine(DoFade(canvasGroup, canvasGroup.alpha, 1));
    }

    private IEnumerator DoFade(CanvasGroup canvas, float start, float end)
    {
        float counter = 0f;
        while(counter < duration)
        {
            counter += Time.deltaTime;
            canvas.alpha = Mathf.Lerp(start, end, counter / duration);
            yield return null;
        }
    }

    private void PlayAudio()
    {
        var audio = GetComponent<AudioSource>();
        audio.volume = PlayerPrefsController.GetSoundsPrefs();
        audio.Play();
    }

    private void ShowStars()
    {
        var lives = FindObjectOfType<LivesHandler>();
        int noLives = lives.GetTotalLives();
        int maxLives = lives.GetMaximumLives();
        int half = (maxLives - 1) / 2;
        if (noLives >= maxLives)
        {
            EnableStars(0);
        }
        else if (noLives >= half)
        {
            EnableStars(1);
        } else
        {
            EnableStars(2);
        }
    }

    // index can be 0, 1 or 2
    private void EnableStars(int index)
    {
        stars[index].SetActive(true);
        int currentLevel = GetCurrentLevel();
        PlayerPrefsController.SetStarPrefs(currentLevel, index + 1);
    }


    // index = 0 <=> currentLevel = 1
    private void SetLevelPrefs()
    {
        int indexLevel = PlayerPrefsController.GetLevelPrefs();
        int max_level = PlayerPrefsController.GetMaxLevel();
        if (max_level- indexLevel <= 1)             //checking if it is last / maximum level
            return;
        int currentLevel = GetCurrentLevel();       //checking last enabled level 
        if (currentLevel - 1 != indexLevel)
            return;
        indexLevel += 1;
        PlayerPrefsController.SetLevelPrefs(indexLevel);
    }

    private int GetCurrentLevel()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        string[] strings = sceneName.Split(' ');
        string lastString = strings[strings.Length - 1];
        int currentLevel = int.Parse(lastString);
        return currentLevel;
    }
}
