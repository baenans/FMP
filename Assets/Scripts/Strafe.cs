using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Strafe : MonoBehaviour
{
    public float speed = 10f;
    private float jumpforce = 50f;
    private float gravity = 30f;
    private Vector3 moves = Vector3.zero;

    void Start()
    {

    }


    void Update()
    {
        CharacterController Controller = gameObject.GetComponent<CharacterController>();


        moves = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); moves = transform.TransformDirection(moves);
        moves *= speed;

        if (Input.GetButtonDown("Jump") && Controller.isGrounded)
        {
            moves.y = jumpforce;

        }
        moves.y -= gravity * Time.deltaTime;

        Controller.Move(moves * Time.deltaTime);
    }
}