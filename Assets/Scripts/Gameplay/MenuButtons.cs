using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] List<Button> buttons = null;

    private Color32 disabledColorButton = new Color32(255, 255, 255, 100);
    private Color32 disabledColorText = new Color32(23, 32, 36, 100);


    void Start()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        if (index == 1)
        {
            DisableButtons();
        }
    }

    private void DisableButtons()
    {
        int currentLevel = PlayerPrefsController.GetLevelPrefs();
        for(int i = currentLevel + 1; i < buttons.Count; i++)
        {
            buttons[i].enabled = false;
            ChangeButtonColor(buttons[i]);
        }
    }

    private void ChangeButtonColor(Button button)
    {
        button.GetComponent<Image>().color = disabledColorButton;
        foreach(Transform child in button.transform)
        {
            child.GetComponent<Text>().color = disabledColorText;
        }
    }

}
