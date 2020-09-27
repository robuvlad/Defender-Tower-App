using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderSelection : MonoBehaviour
{
    [SerializeField] Defender defender = null;

    [Header("Not enough points panel")]
    [SerializeField] GameObject panel = null;

    [Header("Sprite Locked")]
    [SerializeField] GameObject locker = null;

    private float timeToUnlock = 1.0f;
    private const string IS_SELECTED_PLACE_ANIM_PARAM = "isSelected";
    private bool isDefenderSelected = false;

    void Start()
    {
        locker.SetActive(false);
        panel.SetActive(false);
        if (CheckDefenderAvailability() == false)
        {
            locker.SetActive(true);
        }
    }

    private void OnMouseDown()
    {
        if (CheckDefenderAvailability() == true)
        {
            HandleDefender();
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

    private void HandleDefender()
    {
        if (isDefenderSelected == false)
        {
            SetAllDefenderSelections();
            isDefenderSelected = true;
            HandleSelectedDefender();
        }
        else
        {
            SetAllDefenderSelections();
            HandleUnselectedDefender();
            DisableFreePlaces();
        }
    }

    private void HandleSelectedDefender()
    {
        var points = FindObjectOfType<PointsHandler>() as PointsHandler;
        if (points.GetTotalPoints() >= defender.GetPoints())
        {
            ShowFreePlaces();
            var defenders = FindObjectsOfType<DefenderSelection>();
            foreach (DefenderSelection def in defenders)
            {
                LockDefender(def);
            }
            UnlockDefender();
            PlaceDefender(defender);
        }
        else
        {
            StartCoroutine(ShowNotEnoughPoints());
        }
    }

    private void HandleUnselectedDefender()
    {
        var defenders = FindObjectsOfType<DefenderSelection>();
        foreach (DefenderSelection def in defenders)
        {
            LockDefender(def);
        }
        PlaceDefender(null);
    }

    public void SetAllDefenderSelections()
    {
        var defenderSelections = FindObjectsOfType<DefenderSelection>();
        foreach (DefenderSelection defenderSelection in defenderSelections)
        {
            defenderSelection.SetDefenderSelected(false);
        }
    }

    private void SetDefenderSelected(bool isDefSel)
    {
        isDefenderSelected = isDefSel;
    }

    private void DisableFreePlaces()
    {
        var places = FindObjectsOfType<PositionDefenders>();
        foreach (PositionDefenders place in places)
        {
            if (place.HasDefender() == false)
            {
                var animator = place.GetComponent<Animator>();
                animator.SetBool(IS_SELECTED_PLACE_ANIM_PARAM, false);
            }
        }
    }


    public void LockDefender(DefenderSelection def)
    {
        def.GetComponent<SpriteRenderer>().color = new Color32(50, 50, 50, 255);
    }

    public void UnlockDefender()
    {
        GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
    }

    private void PlaceDefender(Defender def)
    {
        var positionDefs = FindObjectsOfType<PositionDefenders>();
        foreach(PositionDefenders pos in positionDefs)
        {
            pos.SetDefender(def);
        }
    }

    private IEnumerator ShowNotEnoughPoints()
    {
        panel.SetActive(true);
        yield return new WaitForSeconds(timeToUnlock);
        panel.SetActive(false);
    }

    private void ShowFreePlaces()
    {
        var places = FindObjectsOfType<PositionDefenders>();
        foreach(PositionDefenders place in places)
        {
            if (place.HasDefender() == false)
            {
                var animator = place.GetComponent<Animator>();
                animator.SetBool(IS_SELECTED_PLACE_ANIM_PARAM, true);
            }
        }
    }
}
