using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Book : MonoBehaviour {
<<<<<<< HEAD
=======
    public Rigidbody rb;
>>>>>>> 49371caf48a1cf4c5c3f76ec4715b69902f575cd
	// Use this for initialization
	void Start () {
        

    }
<<<<<<< HEAD
    void OnTriggerEnter(Collider other)
=======
    void OnTriggerStay(Collider other)
>>>>>>> 49371caf48a1cf4c5c3f76ec4715b69902f575cd
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
