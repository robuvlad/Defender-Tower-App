using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowUpgrader : MonoBehaviour
{

    private void OnMouseDown()
    {
        Vector3 pos = gameObject.transform.parent.parent.gameObject.transform.position;
        var upgradeDefender = gameObject.transform.parent.parent.gameObject.GetComponent<Defender>().GetUpgradeDefender();
        Debug.Log(upgradeDefender);
        Destroy(gameObject.transform.parent.parent.gameObject);
        Instantiate(upgradeDefender, pos, Quaternion.identity);
    }
}
