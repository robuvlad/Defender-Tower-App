using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedStoreButton : MonoBehaviour
{
    private StoreButton selectedStoreBtn = null;
    private int indexButton;
    private GameObject buyButton;
    private GameObject soldText;

    void Update()
    {
        selectedStoreBtn = StoreButton.GetSelectedStoreBtn();
        if (selectedStoreBtn != null)
        {
            indexButton = selectedStoreBtn.GetIndexButton();
            buyButton = selectedStoreBtn.GetBuyButton();
            soldText = selectedStoreBtn.GetSoldText();
        }
    }

    public void BuyDefender()
    {
        int score = PlayerPrefsController.GetScorePrefs();
        var img = selectedStoreBtn.transform.GetChild(0).GetComponent<Image>();
        var scoreText = img.GetComponent<ScoreText>();
        if (score >= scoreText.GetScore() && img != null && scoreText != null)
        {
            var scoreObj = FindObjectOfType<Score>();
            int index = indexButton;
            PlayerPrefsController.SetBoughDefenderPrefs(index, 1);
            score -= scoreText.GetScore();
            PlayerPrefsController.SetScorePrefs(score);
            scoreObj.ShowScore();
            buyButton.SetActive(false);
            soldText.SetActive(true);
            img.color = new Color32(255, 255, 255, 255);
        }
    }
}
