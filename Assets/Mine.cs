using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject player;
    public float currencyAttractionSpeed;
    public int timeLeft = 5;
    public bool hasCoroutineStarted = false;
    public bool hasExploded = false;

    public GameObject Parent;

    public GameObject explosionEffect;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasCoroutineStarted == true)
        {
            StartCoroutine("LoseTime");
        }
        else if (hasCoroutineStarted == false)
        {
            StopCoroutine("LoseTime");
        }
        //transform.parent.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);

    }

    void Explode()
    {
        if (!hasExploded)
        {
            Instantiate(explosionEffect, transform.position, transform.rotation);
        }
        print("boom");
        hasCoroutineStarted = false;
        hasExploded = true;
        StopCoroutine("LoseTime");
        Destroy(Parent);
        transform.GetComponent<Bang>().Explode();
    }
    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeLeft);
            Explode();

            hasCoroutineStarted = true;
        }
    }
   


    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (hasExploded == false)
            {
                hasCoroutineStarted = true;
            }
            else
            {
                hasCoroutineStarted = false;
            }
            SphereCollider myCollider = transform.GetComponent<SphereCollider>();
            myCollider.radius = 50f; // or whatever radius you want.
            player = GameObject.Find("Player");
            transform.parent.position = Vector3.MoveTowards(transform.position, player.transform.position, (currencyAttractionSpeed * Time.deltaTime));
        }
    }

}
