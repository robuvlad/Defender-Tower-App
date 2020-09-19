using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreButton : MonoBehaviour
{
    [SerializeField] Text priceText = null;

    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnPress);
    }

    private void OnPress()
    {
        EnableImage();
        ShowPrice();
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
        image.color = new Color32(100, 100, 100, 255);
    }

    private void ShowPrice()
    {
        var scoreText = gameObject.transform.GetChild(0).GetComponent<ScoreText>();
        priceText.text = scoreText.GetScore().ToString();
    }
}
