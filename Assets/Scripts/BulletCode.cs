using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCode : MonoBehaviour {

	public float Speed;
	public float Damage;
	public float Drop;
	public Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody> ();
		rb.AddForce (transform.forward * Speed);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
