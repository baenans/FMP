using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeVision : MonoBehaviour {
    public bool enemyInRange = false;
    public GameObject target;
    // Use this for initialization
    public void OnTriggerStay (Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemyInRange = true;
            return;
        }
        
	}
    private void OnTriggerExit(Collider other)
    {
        enemyInRange = false;
    }


    // Update is called once per frame
    void Update () {
        
		
	}
}
