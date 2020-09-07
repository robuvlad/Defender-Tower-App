using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gametimer : MonoBehaviour
{
    [SerializeField] float extraTime = 0.0f;

    private Slider slider = null;
    private float totalTime;

    void Start()
    {
        SetupTimer();
    }

    void Update()
    {
        UpdateSliderValue();
    }

    private void SetupTimer()
    {
        slider = GetComponent<Slider>() as Slider;
        slider.enabled = false;
        totalTime = extraTime;
        Waves waves = FindObjectOfType<Waves>() as Waves;
        foreach (Wave wave in waves.GetWaves())
        {
            totalTime += wave.GetNoOfEnemies() * wave.GetTimeBetweenEnemies();
        }
        totalTime += waves.GetDelayTime();
    }

    private void UpdateSliderValue()
    {
        slider.value = Time.timeSinceLevelLoad / totalTime;
    }
}
