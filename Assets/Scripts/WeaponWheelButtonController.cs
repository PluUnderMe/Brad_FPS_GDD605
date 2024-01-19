using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class WeaponWheelButtonController : MonoBehaviour
{
    //parrameters for the weapon wheel controller
    public int ID;
    public Animator anim;
    public string itemName;
    public TextMeshProUGUI itemText;
    public Image selectedItem;
    private bool selected = false;
    public Sprite icon;

    WeaponWheelController weaponWheelController;


    // Start is called before the first frame update
    void Start() // allows the weapon wheel controller to find the weapon wheel and its animator
    {
        anim = GetComponent<Animator>();
        weaponWheelController = GameObject.Find("WeaponWheel").GetComponent<WeaponWheelController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (selected) //shows the name of what item ID being selected
        {
            selectedItem.sprite = icon; //can ignore 
            itemText.text = itemName;
            
        }
    }

    public void Selected() // sets the current weapon ID to what was selected
    {
        selected = true;
        weaponWheelController.weaponID = ID;
    }

    public void Deselected()
    {
        selected = false;     
    }

    public void HoverEnter() //these last two are for the hover animations for the weapon wheel
    {
        anim.SetBool("Hover", true);
        itemText.text = itemName;
    }

    public void HoverExit()
    {
        anim.SetBool("Hover", false);
        itemText.text = "";
    }
}
