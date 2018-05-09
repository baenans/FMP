using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlankHit : MonoBehaviour
{
    public Animator anim;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Melee"))
        {
            anim.SetBool("Stab", true);
        }
        if (Input.GetButtonUp("Melee"))
        {
            anim.SetBool("Stab", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Knife"))
        {
            anim.SetTrigger("KnifePlank");
        }
    }
}
