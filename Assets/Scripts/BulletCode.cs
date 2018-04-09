using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCode : MonoBehaviour {

	public float Speed = 10;
	public float Damage;
	public float Drop;
	public Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * Speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        }
        else if (collision.gameObject.tag == "Skybox")
        {
            Destroy(gameObject);
        }
        if (collision.collider.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().enemyHealth -= Damage;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
