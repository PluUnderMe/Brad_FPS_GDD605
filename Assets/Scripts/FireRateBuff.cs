using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRateBuff : MonoBehaviour
{
    public float multiplier = 2f;
    public float duration = 10f;

    [SerializeField] GameObject player;
    [SerializeField] GameObject chosenWeapon;

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            StartCoroutine(Pickup(other));
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            GetComponent<Collider>().enabled = false;
        }
    }

    IEnumerator Pickup(Collider player)
    {
        Weapon stats = chosenWeapon.GetComponent<Weapon>();

        stats.rateOfFire /= multiplier;

        yield return new WaitForSeconds(duration);

        stats.rateOfFire *= multiplier;

        Destroy(gameObject);
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (player.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.activeInHierarchy == true)
        {
            chosenWeapon = player.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
            return;
        }
        else if (player.gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.activeInHierarchy == true)
        {
            chosenWeapon = player.gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
            return;
        }
        else if (player.gameObject.transform.GetChild(0).gameObject.transform.GetChild(2).gameObject.activeInHierarchy == true)
        {
            chosenWeapon = player.gameObject.transform.GetChild(0).gameObject.transform.GetChild(2).gameObject;
            return;
        }
        else if (player.gameObject.transform.GetChild(0).gameObject.transform.GetChild(3).gameObject.activeInHierarchy == true)
        {
            chosenWeapon = player.gameObject.transform.GetChild(0).gameObject.transform.GetChild(3).gameObject;
            return;
        }


    }
}