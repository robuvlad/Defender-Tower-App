using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    [SerializeField] GameObject nextLevelPanel = null;

    void Start()
    {
        nextLevelPanel.SetActive(false);
    }

    public void ShowPanel()
    {
        nextLevelPanel.SetActive(true);
    }
}
