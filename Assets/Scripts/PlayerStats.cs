using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public float PlayerHealth;
    public float Ammo;
    public float MaxAmmo;
    public float currency;
    public float shotgunKills;
    public float experience;
    public float currentLevel;
    public float smgKills;


    // Update is called once per frame
    void Update ()
    {
        smgKills = Enemy.smgKills;
        shotgunKills = Enemy.shotgunKills;
        currentLevel = PlayerController2.healthlevel;
        experience = PlayerController2.experience;
        PlayerHealth = PlayerController2.playerHealth;
        currency = gameObject.GetComponent<PlayerController2>().currency;
    }

}
