using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionDefenders : MonoBehaviour
{
    private Defender defender = null;

    private Vector3 SPAWNING_POINT = new Vector3(0, 0, -1);

    private void OnMouseDown()
    {
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
                points.DecreasePoints(newDefender.GetPoints());
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
        }
        PositionDefenders[] positions = FindObjectsOfType<PositionDefenders>();
        foreach(PositionDefenders pos in positions)
        {
            pos.SetDefender(null);
        }
    }

    public void SetDefender(Defender def)
    {
        this.defender = def;
    }
}
