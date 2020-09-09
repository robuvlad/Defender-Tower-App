using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] float timeToWait = 0.0f;

    private int sceneIndex;

    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (sceneIndex == 0)
        {
            StartCoroutine(WaitAndContinue());
        }
    }

    private IEnumerator WaitAndContinue()
    {
        yield return new WaitForSeconds(timeToWait);
        sceneIndex += 1;
        SceneManager.LoadScene(sceneIndex);
    }

    public void PlayLevel(int level)
    {
        SceneManager.LoadScene(level);
    }
}
