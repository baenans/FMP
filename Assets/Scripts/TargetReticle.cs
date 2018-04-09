using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetReticle : MonoBehaviour {
    public GameObject Player; //player target for reticle to aim at
    public GameObject Target; //Target reticle
	// Update is called once per frame
	void Update ()
    {
        
            Player = GameObject.FindWithTag("Player");
        
        transform.LookAt(Player.transform.position);
    }
}
