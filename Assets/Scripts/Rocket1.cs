using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket1 : MonoBehaviour {

    public float Speed;
    public float Turning;
    public GameObject Target;
    public GameObject EnemyList;
    public GameObject Reticle;
    bool TargetFound = false;
    public float Range;
    // Use this for initialization
    void Start ()
    {
        EnemyList = GameObject.Find("EnemyList");
        Reticle = transform.GetChild(1).gameObject;
	}

    // Update is called once per frame
    void Update()
    {

        if(Target != null)
{

            //Reticle.transform.SetParent(Target.transform);
           // Reticle.transform.position = (Target.transform.position);
           // Reticle.SetActive(true);
            Vector3 direction = Target.transform.position - transform.position;
            Quaternion toRotation = Quaternion.FromToRotation(transform.forward, direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, Turning * Time.time);
            transform.Translate(transform.forward * Speed * Time.deltaTime, Space.World);
        }
        else
        {
            //EnemyList.GetComponent<TargettingSystem>().InRange(gameObject, Range); cancelled out due to bug in flying
            transform.Translate(transform.forward * Speed * Time.deltaTime, Space.World);
        }


    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            transform.GetChild(0).GetComponent<Bang>().Explode();
            Destroy(gameObject);
        }
    }
}

