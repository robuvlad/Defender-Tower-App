using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Waves : MonoBehaviour
{
    [Header("Configurations")]
    [SerializeField] List<Wave> waves = null;

    [Header("UI Config")]
    [SerializeField] Text waveText = null;

    private int noOfWaves;
    private bool canLoad = false;
    private Gametimer gametimer = null;
    private float waveTime = 0.0f;

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
    }

    private IEnumerator InstantiateNewWave()
    {
        while(noOfWaves > 0)
        {
            SetWaveTextUI(waves.Count - noOfWaves + 1);
            Wave currentWave = waves[waves.Count - noOfWaves];
            gametimer.SetupTimer(currentWave);
            waveTime = 0.0f;
            StartCoroutine(currentWave.InstantiateRandomEnemies());
            yield return new WaitUntil(() => canLoad == true);
            canLoad = false;
            noOfWaves -= 1;
        }
    }

    private void CheckForDeathEnemies()
    {
        if (noOfWaves >= 1)
        {
            Wave currentWave = waves[waves.Count - noOfWaves];
            List<Enemy> enemies = currentWave.GetEnemies();
            bool isNull = false;
            for (int i = 0; i < currentWave.GetEnemies().Count; i++)
            {
                if (enemies[i] != null)
                    isNull = true;
            }
            if (!isNull)
                canLoad = true;
        }
    }

    private void UpdateSlider()
    {
        waveTime += Time.deltaTime;
        gametimer.UpdateSliderValue(waveTime);
    }

    private void SetWaveTextUI(int currentWave)
    {
        waveText.text = "Wave " + currentWave + "/" + waves.Count;
        GetComponent<AudioSource>().Play();
    }

    public List<Wave> GetWaves()
    {
        return waves;
    }
}
