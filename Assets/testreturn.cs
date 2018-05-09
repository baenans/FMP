using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testreturn : MonoBehaviour {
    bool go;

    GameObject player;
    GameObject sword;

    Transform itemToRotate;

    Vector3 locationToPlayer;
	// Use this for initialization
	void Start () {
        go = false;

        player = GameObject.Find("gothgirl");
        sword = GameObject.Find("test_anim");
        sword.GetComponent<MeshRenderer>().enabled = false;

        itemToRotate = gameObject.transform.GetChild(0);

        locationToPlayer = new Vector3(player.transform.position.x, player.transform.position.y + 1, player.transform.position.z) + player.transform.forward * 10f;
        StartCoroutine(Boom());
	}

    IEnumerator Boom()
    {
        go = true;
        yield return new WaitForSeconds(1.5f);
        go = false;

    }
	// Update is called once per frame
	void Update () {
        itemToRotate.transform.Rotate(0, Time.deltaTime * 500, 0);
        if (go)
        {
            transform.position = Vector3.MoveTowards(transform.position, locationToPlayer, Time.deltaTime * 40);
        }
        if (!go)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, player.transform.position.y + 1, player.transform.position.z), Time.deltaTime * 40);
        }
        if (!go && Vector3.Distance(player.transform.position, transform.position) < 1.5 )
        {
            sword.GetComponent<MeshRenderer>().enabled = true;
            Destroy(this.gameObject);
        }
    }
}
