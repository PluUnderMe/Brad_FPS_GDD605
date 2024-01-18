using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class WeaponWheelButtonController : MonoBehaviour
{

    public int ID;
    public Animator anim;
    public string itemName;
    public TextMeshProUGUI itemText;
    public Image selectedItem;
    private bool selected = false;
    public Sprite icon;

    WeaponWheelController weaponWheelController;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        weaponWheelController = GameObject.Find("WeaponWheel").GetComponent<WeaponWheelController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (selected)
        {
            selectedItem.sprite = icon;
            itemText.text = itemName;
            
        }
    }

    public void Selected()
    {
        selected = true;
        weaponWheelController.weaponID = ID;
    }

    public void Deselected()
    {
        selected = false;     
    }

    public void HoverEnter()
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
