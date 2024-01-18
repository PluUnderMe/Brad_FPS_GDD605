using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponWheelController : MonoBehaviour
{
    public Animator anim;
    private bool weaponWheelSelected = false;
    public Image selectedItem;
    public Sprite noImage;
    public int weaponID;
    private bool menuIsOpen = false;
    public GameObject M1911;
    public GameObject AK74;
    public GameObject BennelliM4;
    public GameObject M107;

    [SerializeField] GameObject canvas;

    private WeaponController weaponController;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab) && menuIsOpen == false)
        {
            canvas.SetActive(true);
            weaponWheelSelected = !weaponWheelSelected;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            menuIsOpen = true;
            return;
        }

        if(Input.GetKeyDown(KeyCode.Tab) && menuIsOpen == true)
        {
            weaponWheelSelected = !weaponWheelSelected;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            menuIsOpen = false;
            Invoke("CloseMenu", 0.5f);
            return;
        }

        if (weaponWheelSelected)
        {
            anim.SetBool("OpenWeaponWheel", true);
        }
        else
        {
            anim.SetBool("OpenWeaponWheel", false);
        }
        
        switch (weaponID)
        {

            case 0: //nothing is selecetd
                selectedItem.sprite = noImage;
                break;
            case 1: //M1911
                M1911.SetActive(true);
                AK74.SetActive(false);
                BennelliM4.SetActive(false);
                M107.SetActive(false);
                break;
            case 2: //AK74
                M1911.SetActive(false);
                AK74.SetActive(true);
                BennelliM4.SetActive(false);
                M107.SetActive(false);
                break;
            case 3: //BennelliM4
                M1911.SetActive(false);
                AK74.SetActive(false);
                BennelliM4.SetActive(true);
                M107.SetActive(false);
                break;
            case 4: //M107
                M1911.SetActive(false);
                AK74.SetActive(false);
                BennelliM4.SetActive(false);
                M107.SetActive(true);
                break;

        }
        
        weaponController.currentAmmo = weaponID;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        weaponController = GameObject.Find("MainCamera").GetComponent<WeaponController>();
    }

    void CloseMenu()
    {
        canvas.SetActive(false);
    }

}
