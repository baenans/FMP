﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFollow : MonoBehaviour {

	public float CameraMoveSpeed = 120.0f;
	public GameObject CameraFollowObj;
	public float clampAngle = 80.0f;
	public float inputSensitivity = 150.0f;
	public GameObject CameraObj;
	public GameObject PlayerObj;
	public float camDistanceXToPlayer;
	public float camDistanceYToPlayer;
	public float camDistanceZToPlayer;
	public float mouseX;
	public float mouseY;
	public float finalInputX;
	public float finalInputZ;
	public float smoothX;
	public float smoothY;
	private float rotY = 0.0f;
	private float rotX = 0.0f;
    public bool lockCursor = true;
    public GameObject player;
    public float JoypadSensitivity = 1;
    public float threshold;
    public Animator anim;
    // Use this for initialization
    void Start () {
        
        Vector3 rot = transform.localRotation.eulerAngles;
		rotY = rot.y;
		rotX = rot.x;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
       Death();

        // We setup the rotation of the sticks here
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            lockCursor = !lockCursor;
        }
        Cursor.lockState = lockCursor ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !lockCursor;

        float inputX = Input.GetAxis ("RightStickHorizontal") * JoypadSensitivity;
		float inputZ = Input.GetAxis ("RightStickVertical") * JoypadSensitivity;
		mouseX = Input.GetAxis ("Mouse X");
		mouseY = Input.GetAxis ("Mouse Y");
		finalInputX = inputX + mouseX;
		finalInputZ = inputZ + mouseY;

		rotY += finalInputX * inputSensitivity * Time.deltaTime;
		rotX += finalInputZ * inputSensitivity * Time.deltaTime;

		rotX = Mathf.Clamp (rotX, -clampAngle, clampAngle);

		Quaternion localRotation = Quaternion.Euler (rotX, rotY, 0.0f);
		transform.rotation = localRotation;


       
    }

    void CheckScript()
    {
    }


    void LateUpdate () {
		CameraUpdater ();
	}

	void CameraUpdater() {
		// set the target object to follow
		Transform target = CameraFollowObj.transform;

		//move towards the game object that is the target
		float step = CameraMoveSpeed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, target.position, step);
	}
    IEnumerator Waitbeforereset()
    {
        yield return new WaitForSeconds(1.6f);
<<<<<<< HEAD
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
=======
<<<<<<< HEAD
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
=======
        SceneManager.LoadScene("testArena");
>>>>>>> 197a87e2433339b1db2c2d2b6c8e4591c84d238d
>>>>>>> 49371caf48a1cf4c5c3f76ec4715b69902f575cd
    }
    void Death()
    {
        if (PlayerController2.playerHealth <= 0 || transform.position.y < threshold)
        {
            //player.gameObject.SetActive(false);
            anim.SetTrigger("Death");
            StartCoroutine(Waitbeforereset());
            PlayerController2.playerHealth = 0;

        }
    }
}
