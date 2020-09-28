using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] List<Image> images = null;
    [SerializeField] Text scoreText = null;
    [SerializeField] Text priceText = null;

    void Start()
    {
        ShowScore();
        ShowImages();
    }

    private void ShowImages()
    {
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

    public void ShowScore()
    {
        int score = PlayerPrefsController.GetScorePrefs();
        scoreText.text = score.ToString();
    }
}
