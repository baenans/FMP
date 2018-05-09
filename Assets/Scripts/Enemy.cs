using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public float enemyHealth = 100.0f;
    public GameObject Target;
    public static bool AutoAim;
    public event System.Action OnDeath;

    public static float shotgunKills;
    public static float smgKills;
    public GameObject shotgun;
    public GameObject smg;
    public GameObject drop;
    int maxSpawnObjects = 10;
    public Vector3 position;

    public bool canDropItem;
    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update() {

        if (enemyHealth <= 0)
        {
            /*GameObject drops = drop[Random.Range(1, drop.Length)];
            Vector3[] spawnPositions = new[] { new Vector3(20, 5, 0), new Vector3(20, 3, 0), new Vector3(20, 1, 0), new Vector3(20, -1, 0), new Vector3(20, -3, 0), new Vector3(20, -5, 0) };
            Quaternion spawnRotation = Quaternion.identity;
            for (int i = 1; i < 6; i++)
            {
                Instantiate(drops, spawnPositions[i], spawnRotation);
            }*/

            if (canDropItem == true)
            {
                Instantiate(drop, transform.position + transform.right * -1, drop.transform.rotation);
                Instantiate(drop, transform.position + transform.right * 1, drop.transform.rotation);
            }
            //GameObject go1 = (GameObject)Instantiate(drop, Vector3.zero, Quaternion.identity);
            //GameObject go2 = (GameObject)Instantiate(drop, Vector3.zero, Quaternion.identity);
            //insert currency spawn anim here
            ShotgunChecker();
            SmgChecker();

            if (OnDeath != null)
            {
                OnDeath();
                
            }
            gameObject.SetActive(false);
            PlayerController2.experience += 100;
        }

    }


    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "ConeOfVision")
        {
            Target.gameObject.SetActive(true);
            AutoAim = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Target.gameObject.SetActive(false);
        AutoAim = false;
    }

    void ShotgunChecker()
    {
        shotgun = GameObject.Find("Shotgun");
        if (shotgun != null)
        {
            if (shotgun.activeSelf)
            {
                shotgunKills += 1;
            }
        }
        else
        {

        }
    }
    void SmgChecker()
    {
        smg = GameObject.Find("SMG");
        if (smg != null)
        {
            if (smg.activeSelf)
            {
                smgKills += 1;
            }
        }
        else
        {

        }
    }



}
