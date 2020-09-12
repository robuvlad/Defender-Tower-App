using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Waves : MonoBehaviour
{
    [Header("Configurations")]
    [SerializeField] List<Wave> waves = null;
    [SerializeField] float delayTime;

    [Header("UI Config")]
    [SerializeField] Text waveText = null;

    private int noOfWaves;

    void Start()
    {
        noOfWaves = waves.Count;
        StartCoroutine(InstantiateNewWave());
    }

    private IEnumerator InstantiateNewWave()
    {
        while(noOfWaves > 0)
        {
            SetWaveTextUI(waves.Count - noOfWaves + 1);
            Wave currentWave = waves[waves.Count - noOfWaves];
            float totalTime = currentWave.GetNoOfEnemies() * currentWave.GetTimeBetweenEnemies() + delayTime;
            StartCoroutine(currentWave.InstantiateRandomEnemies());
            noOfWaves -= 1;
            yield return new WaitForSeconds(totalTime);
        }
    }

    private void SetWaveTextUI(int currentWave)
    {
        waveText.text = "Wave " + currentWave + "/" + waves.Count;
        GetComponent<AudioSource>().Play();
    }

    public float GetDelayTime()
    {
        return delayTime;
    }

    public List<Wave> GetWaves()
    {
        return waves;
    }
}
