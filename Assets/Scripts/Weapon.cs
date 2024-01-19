using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //Parameters 
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 33f;
    public float rateOfFire = 1f;

    //Cached References
    [SerializeField] Camera playerCam;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitVFX;

    private WeaponController weaponController;

    bool canShoot = true;

    //States

    private void Start()
    {
        weaponController = GameObject.Find("MainCamera").GetComponent<WeaponController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    private IEnumerator Shoot() //means the ammo count will be affected by what weapon is being used, also projects a ray cast and plays a muzzle flash particle effect
    {

        if (weaponController.ammoTypes[weaponController.currentAmmo] <= 0)
        {
            yield break;
        }


        canShoot = false;

        ProcessRaycast();
        PlayMuzzleFlash();

        weaponController.ammoTypes[weaponController.currentAmmo] -= 1;

        yield return new WaitForSeconds(rateOfFire);
        canShoot = true;
    }

    private void ProcessRaycast() //means the raycast will dectet thing in  range of the weapon stats and adds a vfx to what we hit
    {
        RaycastHit thingWeHit;
        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out thingWeHit, range))
        {
            EnemyHealth target = thingWeHit.transform.GetComponent<EnemyHealth>();
            CreateHitVFX(thingWeHit);
            if (target ==null) { return; }
            target.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }

    private void CreateHitVFX(RaycastHit thingWeHit)
    {
        GameObject impact = Instantiate(hitVFX, thingWeHit.point, Quaternion.identity);
        Destroy(impact, 0.1f);
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }
}
