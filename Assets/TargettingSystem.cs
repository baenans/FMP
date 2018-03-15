using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargettingSystem : MonoBehaviour {


    // Use this for initialization
    public void InRange(GameObject Rocket, float Range)
    {
        int count = transform.childCount;
        int i = 0;
        GameObject Target = null;
        float MinDistance = Range;
        while(i != count)
{
            float Distance = Vector3.Distance(transform.GetChild(i).transform.position, Rocket.transform.position);
            if(Distance <= MinDistance)
{
                MinDistance = Distance;
                Target = transform.GetChild(i).gameObject;
            }
            i += 1;
        }

        Rocket.GetComponent<Rocket1>().Target = Target;
    }


    // Update is called once per frame
    void Update () {
		
	}
}
