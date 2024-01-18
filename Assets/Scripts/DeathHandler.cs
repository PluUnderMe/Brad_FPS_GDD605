using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{

    [SerializeField] Canvas goCanvas;

    // Start is called before the first frame update
    void Start()
    {
        goCanvas.enabled = false;
    }

    public void HandleDeath()
    {
        goCanvas.enabled = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
    }
}
