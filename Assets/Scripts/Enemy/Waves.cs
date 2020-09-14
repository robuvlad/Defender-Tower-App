﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Waves : MonoBehaviour
{
    [Header("Configurations")]
    [SerializeField] List<Wave> waves = null;
    [SerializeField] float timeBetweenWaves = 0.0f;

    [Header("UI Config")]
    [SerializeField] Text waveText = null;

    private int noOfWaves;
    private bool canLoad = false;
    private Gametimer gametimer = null;
    private float waveTime = 0.0f;
    private Wave currentWave = null;
    private bool canCheckForDeathEnemies = false;

    void Start()
    {
        noOfWaves = waves.Count;
        gametimer = FindObjectOfType<Gametimer>() as Gametimer;
        StartCoroutine(InstantiateNewWave());
    }


    void Update()
    {
        CheckForDeathEnemies();
        UpdateSlider();
        FinishedLevel();
    }

    private IEnumerator InstantiateNewWave()
    {
        while(noOfWaves > 0)
        {
            SetWaveTextUI(waves.Count - noOfWaves + 1);
            currentWave = waves[waves.Count - noOfWaves];
            gametimer.SetupTimer(currentWave);
            waveTime = 0.0f;
            StartCoroutine(currentWave.InstantiateRandomEnemies());
            canCheckForDeathEnemies = true;
            yield return new WaitUntil(() => canLoad == true);
            canCheckForDeathEnemies = false;
            yield return new WaitForSeconds(timeBetweenWaves);
            canLoad = false;
            noOfWaves -= 1;
        }
    }

    private void CheckForDeathEnemies()
    {
        if (noOfWaves >= 1 && currentWave != null && canCheckForDeathEnemies == true)
        {
            List<Enemy> enemies = currentWave.GetEnemies();
            for (int i = 0; i < currentWave.GetEnemies().Count; i++)
            {
                if (enemies[i] != null)
                    return;
            }
            canLoad = true;
        }
    }

    private void FinishedLevel()
    {
        if (noOfWaves == 0)
        {
            List<Enemy> enemies = waves[waves.Count - noOfWaves - 1].GetEnemies();
            foreach(Enemy enemy in enemies)
            {
                if (enemy != null)
                    return;
            }
            FindObjectOfType<NextLevel>().ShowPanel();
            noOfWaves -= 1;
        }
    }

    private void UpdateSlider()
    {
        waveTime += Time.deltaTime;
        gametimer.UpdateSliderValue(waveTime);
    }

    private void SetWaveTextUI(int currentWaveIndex)
    {
        waveText.text = "Wave " + currentWaveIndex + "/" + waves.Count;
        GetComponent<AudioSource>().Play();
    }

    public List<Wave> GetWaves()
    {
        return waves;
    }
}
