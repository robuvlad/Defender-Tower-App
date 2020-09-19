using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreButton : MonoBehaviour
{
    [SerializeField] Text priceText = null;
    [SerializeField] GameObject soldText = null;
    [SerializeField] GameObject buyButton = null;

    private static StoreButton selectedStoreBtn = null;

    void Start()
    {
        /*
        PlayerPrefsController.SetScorePrefs(10000);
        
        PlayerPrefs.DeleteKey("Bought_Defender");
        for(int i=1; i < 6; i++)
            PlayerPrefs.DeleteKey("Bought_Defender" + i.ToString());
        */

        buyButton.SetActive(false);
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnPress);
    }

    private void OnPress()
    {
        EnableImage();
        ShowPrice();
        EnableBuyButton();
    }

    private void EnableImage()
    {
        var buttons = FindObjectsOfType<StoreButton>();
        foreach (StoreButton btn in buttons)
        {
            var img = btn.GetComponent<Image>();
            img.color = new Color32(255, 255, 255, 255);
        }
        var image = GetComponent<Image>();
        image.color = new Color32(255, 255, 255, 255);
    }

    private void ShowPrice()
    {
        var scoreText = gameObject.transform.GetChild(0).GetComponent<ScoreText>();
        priceText.text = scoreText.GetScore().ToString();
    }

    private void EnableBuyButton()
    {
        var storeButtons = FindObjectsOfType<StoreButton>();
        for (int i = 0; i < storeButtons.Length; i++)
        {
            if (storeButtons[i] == this)
            {
                selectedStoreBtn = storeButtons[i];
                int index = GetIndexButton();
                int nr = PlayerPrefsController.GetBoughtDefenderPrefs(index);
                if (nr == 0)
                {
                    soldText.SetActive(false);
                    buyButton.SetActive(true);
                } else if (nr == 1)
                {
                    soldText.SetActive(true);
                    buyButton.SetActive(false);
                }
            }
        }
    }

    public int GetIndexButton()
    {
        int index = int.Parse(gameObject.name.Split(' ')[1]);
        return index;
    }

    public static StoreButton GetSelectedStoreBtn()
    {
        return selectedStoreBtn;
    }

    public GameObject GetSoldText()
    {
        return soldText;
    }

    public GameObject GetBuyButton()
    {
        return buyButton;
    }
}
