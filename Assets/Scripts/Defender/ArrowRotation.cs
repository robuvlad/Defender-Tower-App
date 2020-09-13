using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRotation : MonoBehaviour
{
    private Quaternion initRotation;

    void Start()
    {
        initRotation = transform.rotation;
    }

    void LateUpdate()
    {
        transform.rotation = initRotation;
    }
}
