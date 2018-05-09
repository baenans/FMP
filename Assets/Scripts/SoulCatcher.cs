using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulCatcher : MonoBehaviour {
    // Use this for initialization

    private PlayerController2 currencyInfo;
    public float currency;
	void Start ()
    {
        currencyInfo = GameObject.FindObjectOfType<PlayerController2>();
        //currencyInfo = GetComponent<PlayerController2>();
    }
	
	// Update is called once per frame
	void Update () {
        currency = currencyInfo.currency;
    }
   void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Souls")
        {
            currencyInfo.currency = currencyInfo.currency + 10;
            other.gameObject.SetActive(false);
        }
    }


}
