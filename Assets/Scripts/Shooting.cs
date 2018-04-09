﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public GameObject PlayerStats;
    public GameObject Player;
    public bool Strafe;
    public GameObject Bullet;
    public GameObject Firepoint;
    public LayerMask test;

    public GameObject coneVisionObject;
    public bool InRange;
    public GameObject target;

    public float GunSpeed;
    public float GunDamage;
    public float GunDrop;

    public float MaxAmmo;
    public float Ammo;
    public int pelletCount;
    public float spreadAngle;
    public float pelletFireVel;

    public float FireRate;
    public float FireTimer = 0;

    public static bool ShotgunUpgrade1 = false;
    public static bool ShotgunUpgrade2 = false;

    public static bool SMGUpgrade1 = false;
    public static bool SMGUpgrade2 = false;

    List<Quaternion> pellets;

    // Use this for initialization
    void Awake()
    {

        pellets = new List<Quaternion>(pelletCount);
        for (int i = 0; i < pelletCount; i++)
        {
            pellets.Add(Quaternion.Euler(Vector3.zero));
        }
    }

    // Update is called once per frame
    void Update()
    {

        Strafe = Player.GetComponent<PlayerController2>().Strafe;
        UpdateStats();
        if (Strafe == true)
        {
            Aim();
        }
        else
        {
            ConeVision cv = coneVisionObject.GetComponent<ConeVision>();
            InRange = cv.enemyInRange;
            if (InRange == true)
            {
                WalkingAim();
            }
            else
            {
                transform.localEulerAngles = new Vector3(0, 0, 0);
                target = null;
            }
        }



        if (Input.GetButton("Fire1"))
        {
            if (Ammo >= 1)
            {
                if (FireTimer >= FireRate)
                {
                    Fire();
                    FireTimer = 0;
                }
            }
        }
        FireTimer += Time.deltaTime;
    }

    void UpdateStats()
    {
        PlayerStats ps = PlayerStats.GetComponent<PlayerStats>();
        ps.Ammo = Ammo;
        ps.MaxAmmo = MaxAmmo;
    }


    void WalkingAim()
    {
        if (InRange == true && Enemy.AutoAim == true)
        {
            var objects = GameObject.FindGameObjectsWithTag("Enemy");
            if (!objects.Any())
                return;

            var distances = objects.Select(s => Vector3.Distance(transform.position, s.transform.position)).ToArray();
            var first = distances.First();
            var index = 0;
            var index1 = 0;
            foreach (var distance in distances)
            {
                if (distance < first)
                {
                    index1 = index;
                    break;
                }
                index++;
            }

            var target = objects[index1];
            if (target == null)
                return;

            var p1 = transform.position;
            var p2 = target.transform.position;
            var position = new Vector3(p2.x, p1.y, p2.z); // does not bend to target
            Vector3 test = target.transform.position;
            transform.LookAt(target.transform);
        }
        else
        {
            target = null;
        }
    }

    void Fire()
    {
        int i = 0;
        Ammo -= 1;
        foreach (Quaternion quat in pellets)
        {

            if (GunSpeed == 0 && GunDamage == 0)
            {
                GameObject bullet = Instantiate(Bullet, Firepoint.transform.position, Firepoint.transform.rotation);
                //bullet.transform.rotation = Quaternion.RotateTowards(bullet.transform.rotation, pellets[i], spreadAngle);
            }
            else
            {
                ShotgunUpgrade();
                SMGUpgrade();
                pellets[i] = Random.rotation;
                GameObject bullet = Instantiate(Bullet, Firepoint.transform.position, Firepoint.transform.rotation);
                BulletCode BullInfo = bullet.GetComponent<BulletCode>();
                bullet.transform.rotation = Quaternion.RotateTowards(bullet.transform.rotation, pellets[i], spreadAngle);
                bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.right);
                BullInfo.Speed = GunSpeed;
                BullInfo.Damage = GunDamage;
                BullInfo.Drop = GunDrop;
                
            }
            i++;
        }
    }

    void ShotgunUpgrade()
    {
        if (Enemy.shotgunKills >= 10)
        {
            Shooting.ShotgunUpgrade1 = true;
        }

        if (ShotgunUpgrade1 == true)
        {
            GunSpeed = 100;
        }

        if (ShotgunUpgrade2 == true)
        {
            GunSpeed = 200;
        }
    }

    void SMGUpgrade()
    {
        if (Enemy.smgKills >= 10)
        {
            Shooting.SMGUpgrade1 = true;
        }
        if (SMGUpgrade1 == true)
        {
            GunSpeed = 100;
        }
        if (SMGUpgrade2 == true)
        {
            GunSpeed = 200;
        }
    }

    void RPGUpgrade()
    {

    }
    void Aim()
    {
        RaycastHit hit;
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 NewMe = Camera.main.transform.position + Camera.main.transform.forward;

        if (Physics.Raycast(NewMe, Camera.main.transform.forward, out hit, Mathf.Infinity, test))
        {
            transform.LookAt(hit.point);
            Debug.DrawLine(NewMe, hit.point);
        }
    }
}

