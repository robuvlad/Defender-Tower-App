using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionFlame : MonoBehaviour
{
    [SerializeField] Flame[] flames = null;
    [SerializeField] float timeToFlame = 0.0f;
    [SerializeField] float timeUntilFlame = 0.0f;
    [SerializeField] int points = 0;

    [Header("UI config")]
    [SerializeField] GameObject panel = null;
    [SerializeField] GameObject locker = null;

    [Header("Timer")]
    [SerializeField] GameObject timer = null;

    private bool timerWasPressed = false;
    private float timerDeltaTime = 0.0f;

    void Start()
    {
        panel.SetActive(false);
        locker.SetActive(false);
        if (CheckDefenderAvailability() == false)
        {
            locker.SetActive(true);
        }
    }

    void Update()
    {
        HandleTimerFading();
    }

    private bool CheckDefenderAvailability()
    {
        int index = int.Parse(gameObject.name.Split(' ')[1]);
        int nr = PlayerPrefsController.GetBoughtDefenderPrefs(index);
        if (nr == 0)
            return false;
        else if (nr == 1)
            return true;
        return false;
    }

    private void OnMouseDown()
    {
        if (CheckDefenderAvailability() == true && timerWasPressed == false)
        {
            HandleFlame();
            timerWasPressed = true;
        }
    }

    private void HandleFlame()
    {
        var pointsComp = FindObjectOfType<PointsHandler>();
        float totalPoints = pointsComp.GetTotalPoints();
        if (totalPoints >= points)
        {
            pointsComp.DecreasePoints(points);
            StartCoroutine(StartFlaming());
        }
    }

    private IEnumerator StartFlaming()
    {
        SetFlames(true);
        yield return new WaitForSeconds(timeToFlame);
        SetFlames(false);
    }

    private void SetFlames(bool boolean)
    {
        foreach (Flame flame in flames)
        {
            flame.gameObject.SetActive(boolean);
        }
    }

    private void HandleTimerFading()
    {
        timer.transform.localScale = new Vector2(1.0f, NormalizedTimerFading());
        if (timerWasPressed == true && timer != null)
        {
            timerDeltaTime += Time.deltaTime;
            float scale = NormalizedTimerFading();
            timer.transform.localScale = new Vector2(1.0f, scale);
            if (timerDeltaTime >= timeUntilFlame)
            {
                timerWasPressed = false;
                timerDeltaTime = 0.0f;
            }
        }
    }

    private float NormalizedTimerFading()
    {
        if (timerWasPressed == false)
            return 0.0f;
        float diff = timeUntilFlame - timerDeltaTime;
        float result = diff / timeUntilFlame;
        if (result < 0.0f)
            result = 0.0f;
        if (result > 1.0f)
            result = 1.0f;
        return result;
    }
}
