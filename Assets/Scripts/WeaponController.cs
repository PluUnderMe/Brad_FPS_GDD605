using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class WeaponController : MonoBehaviour
{
    // NONE - 9mm - 7.62 - Slugs - 50.Cal
    public int[] ammoTypes;
    public int currentAmmo;

    [SerializeField] TextMeshProUGUI ammoText;

    private void Update()
    {
        DisplayAmmo();
    }

    private void DisplayAmmo()
    {
        ammoText.text = ammoTypes[currentAmmo].ToString();
    }
}
