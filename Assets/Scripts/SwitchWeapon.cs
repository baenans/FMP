using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapon : MonoBehaviour {

    public int selectedWeapon = 0;
    public Animator anim;
    //public GameObject Wheel;
    //public GameObject weapon1;
    //public GameObject weapon2;
    //public GameObject weapon3;
    //public GameObject weapon4;
    //public GameObject weapon5;

    void Start () {
        SelectWeapon();
        //Wheel.SetActive(false);
        //anim = GetComponent<Animator>();
    }
	
	
	void Update () {
        int previousSelectedWeapon = selectedWeapon;
        if (Input.GetButtonDown("Melee"))
        {
            selectedWeapon = 3;
        }
        if (selectedWeapon == 3)
        {
            anim.SetBool("Melee", true);
        }
        else
        {
            anim.SetBool("Melee", false);
        }
		if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            selectedWeapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
        {
            selectedWeapon = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 4)
        {
            selectedWeapon = 3;
        }

        if (previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon();
        }
    }

    public void SelectWeapon ()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
}
