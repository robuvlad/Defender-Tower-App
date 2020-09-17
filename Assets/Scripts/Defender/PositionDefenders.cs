using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionDefenders : MonoBehaviour
{
    private Defender defender = null;

    private Vector3 SPAWNING_POINT = new Vector3(0, 0, -1);
    private bool hasDefender = false; // checks if the specific place has defender or not
    private const string IS_SELECTED_PLACE_ANIM_PARAM = "isSelected";

    private void OnMouseDown()
    {
        DisableFreePlaces();
        SpawnDefender();
    }

    private void SpawnDefender()
    {
        if (defender != null)
        {
            var points = FindObjectOfType<PointsHandler>() as PointsHandler;
            if (points.GetTotalPoints() >= defender.GetPoints())
            {
                Defender newDefender = Instantiate(defender, transform.position + SPAWNING_POINT, Quaternion.identity) as Defender;
                newDefender.transform.SetParent(gameObject.transform);
                points.DecreasePoints(newDefender.GetPoints());
                hasDefender = true;
                //Destroy(GetComponent<BoxCollider2D>());
            }
            LockDefenders();
        }
    }

    private void LockDefenders()
    {
        DefenderSelection[] defenders = FindObjectsOfType<DefenderSelection>();
        foreach(DefenderSelection def in defenders)
        {
            def.LockDefender(def);
            def.SetAllDefenderSelections();
        }
        PositionDefenders[] positions = FindObjectsOfType<PositionDefenders>();
        foreach(PositionDefenders pos in positions)
        {
            pos.SetDefender(null);
        }
    }

    private void DisableFreePlaces()
    {
        var places = FindObjectsOfType<PositionDefenders>();
        foreach(PositionDefenders place in places)
        {
            if(place.HasDefender() == false)
            {
                var animator = place.GetComponent<Animator>();
                animator.SetBool(IS_SELECTED_PLACE_ANIM_PARAM, false);
            }
        }
    }

    public void SetDefender(Defender def)
    {
        this.defender = def;
    }

    public void SetHasDefender(bool hasDef)
    {
        hasDefender = hasDef;
    }

    public bool HasDefender()
    {
        return hasDefender;
    }
}
