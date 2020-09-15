using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    [SerializeField] GameObject nextLevelPanel = null;
    [SerializeField] float duration = 0.4f;

    void Start()
    {
        nextLevelPanel.SetActive(false);
    }

    public void ShowPanel()
    {
        nextLevelPanel.SetActive(true);
        var canvasGroup = nextLevelPanel.GetComponent<CanvasGroup>();
        StartCoroutine(DoFade(canvasGroup, canvasGroup.alpha, 1));
        GetComponent<AudioSource>().Play();
    }

    private IEnumerator DoFade(CanvasGroup canvas, float start, float end)
    {
        float counter = 0f;
        while(counter < duration)
        {
            counter += Time.deltaTime;
            canvas.alpha = Mathf.Lerp(start, end, counter / duration);
            yield return null;
        }
    }

}
