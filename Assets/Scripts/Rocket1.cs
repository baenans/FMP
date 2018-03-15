using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket1 : MonoBehaviour {

    public float Speed;
    public float Turning;
    public GameObject Target;
    public GameObject EnemyList;
    bool TargetFound = false;
    public float Range;
    // Use this for initialization
    void Start ()
    {
        EnemyList = GameObject.Find("EnemyList");
	}

    // Update is called once per frame
    void Update()
    {

        if(Target != null)
{
            Vector3 direction = Target.transform.position - transform.position;
            //float distance = Vector3.Distance(Target.transform.position, transform.position);
            //direction = direction / distance;

            Quaternion toRotation = Quaternion.FromToRotation(transform.forward, direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, Turning * Time.time);
            transform.Translate(transform.forward * Speed * Time.deltaTime, Space.World);
        }
        else
        {
            EnemyList.GetComponent<TargettingSystem>().InRange(gameObject, Range);
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

