using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    //parrameters
    float zoomIn = 20f;
    float zoomOut = 60f;


    [SerializeField] Camera PlayerCam;

    bool zoomToggle = false;

    void Update() //enables the main camera to be zoomed in when the right mouse button is pressed on seleceted weapons
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
