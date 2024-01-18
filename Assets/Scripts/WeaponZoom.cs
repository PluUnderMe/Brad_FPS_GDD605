using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    float zoomIn = 20f;
    float zoomOut = 60f;


    [SerializeField] Camera PlayerCam;

    bool zoomToggle = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (!zoomToggle)
            {
                zoomToggle = true;
                PlayerCam.fieldOfView = zoomIn;
            }

            else if (zoomToggle)
            {
                zoomToggle = false;
                PlayerCam.fieldOfView = zoomOut;
            }
        }
    }
}
