using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {


    public GameObject Player;
    public bool Strafe;
	public GameObject Bullet;
	public GameObject Firepoint;

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

        if (Strafe == true)
        {
            Aim();
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

	void Fire()
	{
        int i = 0;
		Ammo -= 1;
        foreach (Quaternion quat in pellets)
        {
            pellets[i] = Random.rotation;
            GameObject bullet = Instantiate(Bullet, Firepoint.transform.position, Firepoint.transform.rotation);
            BulletCode BullInfo = bullet.GetComponent<BulletCode>();
            bullet.transform.rotation = Quaternion.RotateTowards(bullet.transform.rotation, pellets[i], spreadAngle);
            bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.right);
            BullInfo.Speed = GunSpeed;
            BullInfo.Damage = GunDamage;
            BullInfo.Drop = GunDrop;
            i++;
        }
	}

    void Aim()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000))
        {
            transform.LookAt(hit.point);
        }
    }
}

