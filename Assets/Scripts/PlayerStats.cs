using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public float PlayerHealth;
    public float Ammo;
    public float MaxAmmo;
	
	// Update is called once per frame
	void Update ()
    {
		PlayerHealth = gameObject.GetComponent<PlayerController2>().playerHealth;
	}
}
