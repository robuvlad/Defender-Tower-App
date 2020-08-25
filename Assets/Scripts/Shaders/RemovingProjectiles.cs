using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemovingProjectiles : MonoBehaviour
{
    private const string TAG = "projectile";

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == TAG)
            Destroy(other.gameObject);
    }
}
