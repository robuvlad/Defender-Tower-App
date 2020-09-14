using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowUpgrader : MonoBehaviour
{

    private void OnMouseDown()
    {
        Vector3 pos = gameObject.transform.parent.parent.gameObject.transform.position;
        var upgradeDefender = gameObject.transform.parent.parent.gameObject.GetComponent<Defender>().GetUpgradeDefender();
        var points = FindObjectOfType<PointsHandler>();
        if (upgradeDefender != null && points.GetTotalPoints() >= upgradeDefender.GetPoints())
        {
            Destroy(gameObject.transform.parent.parent.gameObject);
            Defender def = Instantiate(upgradeDefender, pos, Quaternion.identity) as Defender;
            points.DecreasePoints(def.GetPoints());
        }
    }

}
