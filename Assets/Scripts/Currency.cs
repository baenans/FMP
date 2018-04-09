using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency : MonoBehaviour {
    private Rigidbody rb;
    public GameObject player;
    public float currencyAttractionSpeed;
    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        //transform.parent.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
        
    }
    
        
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = GameObject.Find("Player");
            transform.parent.position = Vector3.MoveTowards(transform.position, player.transform.position, currencyAttractionSpeed * Time.deltaTime);
        }
    }

}
