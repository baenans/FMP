using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class returnTest : MonoBehaviour {
    public GameObject test;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            print("test");
            GameObject clone;
            clone = Instantiate(test, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), transform.rotation) as GameObject;
            print("test");
        }
    }
}
