using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponWheelController : MonoBehaviour
{
    //parramets for the weapon wheel controller
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
        if(Input.GetKeyDown(KeyCode.Tab) && menuIsOpen == false) //allows the weapon wheel to open when tab is pressed allows the cursor to be shown and used while the menu is open
        {
            canvas.SetActive(true);
            weaponWheelSelected = !weaponWheelSelected;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            menuIsOpen = true;
            return;
        }

        if(Input.GetKeyDown(KeyCode.Tab) && menuIsOpen == true) //allows the weapon wheel to close when tab is pressed allows the cursor to dissapear and used while the menu is closed
        {
            weaponWheelSelected = !weaponWheelSelected;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            menuIsOpen = false;
            Invoke("CloseMenu", 0.5f);
            return;
        }

        if (weaponWheelSelected) //sets the open and close animations for the weapon wheel
        {
            anim.SetBool("OpenWeaponWheel", true);
        }
        else
        {
            anim.SetBool("OpenWeaponWheel", false);
        }
        
        switch (weaponID) //sets the weapons in the hirachy to be active based on if their ID is active
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

    private void Start() // sets the cursor to locked at the start
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        weaponController = GameObject.Find("MainCamera").GetComponent<WeaponController>();
    }

    void CloseMenu() //disables the canvas once its been closed
    {
        canvas.SetActive(false);
    }

}
