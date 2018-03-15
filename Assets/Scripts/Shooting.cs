using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    public GameObject PlayerStats;
    public GameObject Player;
    public bool Strafe;
	public GameObject Bullet;
	public GameObject Firepoint;
    public LayerMask test;

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

    List<Quaternion> pellets;

	// Use this for initialization
	void Awake () {

        pellets = new List<Quaternion>(pelletCount);
        for (int i = 0; i < pelletCount; i++)
        {
            pellets.Add(Quaternion.Euler(Vector3.zero));
        }
	}
	
	// Update is called once per frame
	void Update () {

        Strafe = Player.GetComponent<PlayerController2>().Strafe;
        UpdateStats();
        if (Strafe == true)
        {
            Aim();
        }
        else
        {
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }

        

		if (Input.GetButton("Fire1")) 
		{
			if (Ammo >= 1) {
				if (FireTimer >= FireRate) {
					Fire ();
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

