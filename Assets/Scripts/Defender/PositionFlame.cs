using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionFlame : MonoBehaviour
{
    [SerializeField] Flame[] flames = null;
    [SerializeField] float timeToFlame = 0.0f;
    [SerializeField] int points = 0;

    [Header("UI config")]
    [SerializeField] GameObject panel = null;
    [SerializeField] GameObject locker = null;

    void Start()
    {
        panel.SetActive(false);
        locker.SetActive(false);
        if (CheckDefenderAvailability() == false)
        {
            locker.SetActive(true);
        }
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
        if (CheckDefenderAvailability() == true)
        {
            HandleFlame();
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
}
