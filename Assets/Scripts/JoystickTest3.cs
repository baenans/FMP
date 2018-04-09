using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickTest3 : MonoBehaviour
{
    public GameObject Shút;
    public int weapon;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Controller")
        {
            Shút.GetComponent<SwitchWeapon>().selectedWeapon = weapon;
            Shút.GetComponent<SwitchWeapon>().SelectWeapon();
        }
    }
}
