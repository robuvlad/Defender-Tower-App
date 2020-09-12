using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gametimer : MonoBehaviour
{
    [SerializeField] float extraTime = 0.0f;
    private Animator animator = null;

    private Slider slider = null;
    private float totalTime;

    private const float MAX_SLIDER_VALUE = 1.0f;
    private const float MIN_SLIDER_VALUE = 0.0f;
    private const string IS_MAX_STRING = "isMax";

    void Start()
    {
        animator = GetComponentInChildren<Animator>() as Animator;
    }

    public void SetupTimer(Wave currentWave)
    {
        slider = GetComponent<Slider>() as Slider;
        slider.enabled = false;
        slider.value = MIN_SLIDER_VALUE;
        totalTime = extraTime;
        totalTime += currentWave.GetNoOfEnemies() * currentWave.GetTimeBetweenEnemies() - currentWave.GetTimeBetweenEnemies();
    }

    public void UpdateSliderValue(float waveTime)
    {
        slider.value = waveTime / totalTime;
        if (slider.value >= MAX_SLIDER_VALUE)
        {
            animator.SetBool(IS_MAX_STRING, true);
        }
        else
        {
            animator.SetBool(IS_MAX_STRING, false);
        }
    }
}
