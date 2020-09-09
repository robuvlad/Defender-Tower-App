using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameplay : MonoBehaviour
{
    [SerializeField] GameObject panel = null;

    private bool isPaused = false;

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
            Time.timeScale = 1;
            SetPanelInactive();
            isPaused = false;
        }
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
