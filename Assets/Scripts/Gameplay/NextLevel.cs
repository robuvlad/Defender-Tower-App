using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        var canvasGroup = nextLevelPanel.GetComponent<CanvasGroup>();
        StartCoroutine(DoFade(canvasGroup, canvasGroup.alpha, 1));
        PlayAudio();
        ShowStars();
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
        GetComponent<AudioSource>().Play();
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

    private void EnableStars(int index)
    {
        stars[index].SetActive(true);
    }
}
