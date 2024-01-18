using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRateBuff : MonoBehaviour
{
    public float multiplier = 1.5f;
    public float duration = 10f;

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            StartCoroutine(Pickup(other));
        }
    }

    IEnumerator Pickup(Collider player)
    {
        Weapon stats = GetComponent<Weapon>();
        stats.rateOfFire *= multiplier;

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(duration);

        stats.rateOfFire /= multiplier;

        Destroy(gameObject);
    }
}