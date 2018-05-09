using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour {
    public Animator anim;
    public Rigidbody rb;
    public float Damage;
    public bool attacking = false;
    public GameObject test;
    // Use this for initialization
    void Start ()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
        void Update ()
    {
        //rb.transform.localEulerAngles = new Vector3(-72.485f, -121.587f, -54.768f);
        //rb.transform.position = new Vector3(0.3245453f, 0.5910016f, -0.09316736f);
        if (Input.GetButtonDown("Melee"))
        {
<<<<<<< HEAD
            attacking = true;
=======
<<<<<<< HEAD
            attacking = true;
=======
>>>>>>> 197a87e2433339b1db2c2d2b6c8e4591c84d238d
>>>>>>> 49371caf48a1cf4c5c3f76ec4715b69902f575cd
            anim.SetBool("Stab", true);
        }
        if (Input.GetButtonUp("Melee"))
        {
<<<<<<< HEAD
            attacking = false;
=======
<<<<<<< HEAD
            attacking = false;
=======
>>>>>>> 197a87e2433339b1db2c2d2b6c8e4591c84d238d
>>>>>>> 49371caf48a1cf4c5c3f76ec4715b69902f575cd
            anim.SetBool("Stab", false);
        }

        if (Input.GetButtonDown("Fire1"))
        {
           
            //GameObject clone;
            //clone = Instantiate(test, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), transform.rotation) as GameObject;
            
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") && attacking == true)
        {
            other.gameObject.GetComponent<Enemy>().enemyHealth -= Damage;
        }
    }
}
