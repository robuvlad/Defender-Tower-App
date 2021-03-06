﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameplay : MonoBehaviour
{
    [SerializeField] GameObject panel = null;

    private bool isPaused = false;
    private const string MENU_SCENE = "Menu";

    void Start()
    {
        SetPanelInactive();
    }

    public void Pause()
    {
        if (!isPaused)
        {
            Time.timeScale = 0;
            SetPanelActive();
            isPaused = true;
        }
    }

    public void Resume()
    {
        if (isPaused)
        {
            Time.timeScale = FindObjectOfType<GameSpeed>().GetCurrentTimeScale();
            SetPanelInactive();
            isPaused = false;
        }
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(MENU_SCENE);
        Time.timeScale = 1;
    }

    public void NextLevel()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index + 1);
        Time.timeScale = 1;
    }

    private void SetPanelInactive()
    {
        panel.SetActive(false);
    }

    private void SetPanelActive()
    {
        panel.SetActive(true);
    }
}
