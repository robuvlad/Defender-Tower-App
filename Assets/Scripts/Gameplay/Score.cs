using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] List<Image> images = null;
    [SerializeField] Text scoreText = null;
    [SerializeField] Text priceText = null;

    private int score;

    void Start()
    {
        score = PlayerPrefsController.GetScorePrefs();
        scoreText.text = score.ToString();
        ShowImages();
    }

    private void ShowImages()
    {
        PlayerPrefsController.SetBoughDefenderPrefs(0, 1);
        for(int i = 0; i < images.Count; i++)
        {
            int value = PlayerPrefsController.GetBoughtDefenderPrefs(i);
            if (value == 0)
            {
                images[i].color = new Color32(30, 30, 30, 255);
            }
            else if (value == 1)
            {
                images[i].color = new Color32(255, 255, 255, 255);
            }
        }
    }

    public void IncreaseScore(int number)
    {
        score += number;
    }

    public void DecreaseScore(int number)
    {
        if (score >= number)
        {
            score -= number;
        }
    }

    public int GetScore()
    {
        return score;
    }

    public void SetScore(int s)
    {
        score = s;
    }
}
