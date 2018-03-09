using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject player;
    GameManager script;


    // Use this for initialization
    void Start ()
    {
      

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Strafe"))
        {
			player.GetComponent<PlayerController>().Strafe = true;
            
        }
        else if (Input.GetButtonUp("Strafe"))
        {
			player.GetComponent<PlayerController>().Strafe = false;
            
        }
        if (GameObject.Find("Cube").GetComponent<PlayerController>().playerHealth <= 0) //something aint right here
        {
            script = GetComponent<GameManager>();
            script.enabled = false;
        }
    }

    }
