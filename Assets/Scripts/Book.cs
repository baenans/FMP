using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Book : MonoBehaviour {
	// Use this for initialization
	void Start () {
        

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("testArena");
            //Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
