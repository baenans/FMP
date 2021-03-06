﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bang : MonoBehaviour {

    public float Damage;
    public float BlastSize;
    public GameObject[] InRange = new GameObject[30];
    int i;
    public bool isMine = false;
    public Transform player;
    public Transform mine;

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<SphereCollider>().radius = BlastSize;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hi");
        FindSpace();
        InRange[i] = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        FindItem(other.gameObject);
        InRange[i] = null;
    }

    void FindSpace()
    {
        int l = 0;

        while (InRange[l] != null)
        {
            l += 1;
        }
        i = l;
    }

    void FindItem(GameObject Find)
    {
        int l = 0;

        while (InRange[l] != Find)
        {
            l += 1;
        }
        i = l;
    }

    public void Explode()
    {
        i = 0;
        while (i != 30)
        {
            if (InRange[i] != null)
            {
                if (InRange[i].tag == "Enemy" && isMine == false)
                {
                    InRange[i].GetComponent<Enemy>().enemyHealth -= Damage;
                }
                if (InRange[i].tag == "Player" && isMine == true)
                {
                    player = GameObject.Find("Player").transform;

                    float proximity = (mine.transform.position - player.transform.position).magnitude;

                    PlayerController2.playerHealth -= 15 / proximity;
                }
                Debug.Log("hit" + InRange[i].name);
            }
            i += 1;
        }
        Destroy(transform.parent.gameObject);
    }

}
