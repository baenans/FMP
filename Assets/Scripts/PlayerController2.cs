using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour {

    public float floating;
    public float falling;
    public float HightOffGround;
    public float turnSmoothing = 15f;
    public Rigidbody RigidbodyT;
    public GameObject Cam;
    float Forward;
    public bool OnGround;
    public float UpPower;
    public float JumpPower;
    public float HC;
    public float VC;
    public float H;
    public float V;
    public float Horizontal;
    public float Vertical;
    public float HorizontalMove;
    public float VerticalMove;
    public float Speed;
    public float Gravity;
    public bool HasDoubleJump;
    public bool Strafe;
    public float DoubleJump;
    public bool Jumped;


    public float X;
    public float Y;
    public float Z;

    // Use this for initialization
    void Start () {
        RigidbodyT = gameObject.GetComponent<Rigidbody>();
	}

    void Update()
    {
        IsGrounded();
        if (Strafe == true)
        {
            RotatingStrafe();
        }
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        
        Inputs();
        transform.Translate(0, UpPower * Time.deltaTime, 0);
        
        GravityForce();
	}


    void IsGrounded()
    {
        Vector3 posMiddle = new Vector3(transform.position.x, transform.position.y - Y, transform.position.z);
        Vector3 posTopLeft = new Vector3(transform.position.x - X, transform.position.y - Y, transform.position.z + Z);
        Vector3 posTopRight = new Vector3(transform.position.x + X, transform.position.y - Y, transform.position.z + Z);
        Vector3 posBotLeft = new Vector3(transform.position.x - X, transform.position.y - Y, transform.position.z - Z);
        Vector3 posBotRight = new Vector3(transform.position.x - X, transform.position.y - Y, transform.position.z - Z);
        

        if (Physics.Raycast(posMiddle, Vector3.down, HightOffGround))
        {
            OnGround = true;
            HasDoubleJump = false;
            UpPower = 0;
        }
        else if (Physics.Raycast(posMiddle, Vector3.down, HightOffGround))
        {
            OnGround = true;
            HasDoubleJump = false;
            UpPower = 0;
        }
        else if (Physics.Raycast(posTopLeft, Vector3.down, HightOffGround))
        {
            OnGround = true;
            HasDoubleJump = false;
            UpPower = 0;
        }
        else if (Physics.Raycast(posTopRight, Vector3.down, HightOffGround))
        {
            OnGround = true;
            HasDoubleJump = false;
            UpPower = 0;
        }
        else if (Physics.Raycast(posBotLeft, Vector3.down, HightOffGround))
        {
            OnGround = true;
            HasDoubleJump = false;
            UpPower = 0;
        }
        else if (Physics.Raycast(posBotRight, Vector3.down, HightOffGround))
        {
            OnGround = true;
            HasDoubleJump = false;
            UpPower = 0;
        }
        else
        {
            OnGround = false;
        }
    }

    void Jump()
    {
        if (OnGround == true)
        {
            UpPower += JumpPower;
        }
        else if (HasDoubleJump == false)
        {
            UpPower += DoubleJump;
            HasDoubleJump = true;
        }
    }

    void PlayerRotationNorm()
    {
        Forward = Cam.transform.eulerAngles.y;
        Vector3 direction = new Vector3(Horizontal, 0, Vertical);
        direction = Camera.main.transform.TransformDirection(direction);
        direction.y = 0.0f;
        Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
        // Create a rotation that is an increment closer to the target rotation from the player's rotation.
        Quaternion newRotation = Quaternion.Lerp(RigidbodyT.rotation, targetRotation, turnSmoothing * Time.deltaTime);
        // Change the players rotation to this new rotation.
        RigidbodyT.MoveRotation(newRotation);
    
        
    }

    void RotatingStrafe()
    {
        Vector3 direction = new Vector3(0f, 0f, 0f);
        direction = Cam.transform.forward;
        direction.y = 0.0f;
        Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
        Quaternion newRotation = Quaternion.Lerp(RigidbodyT.rotation, targetRotation, turnSmoothing * Time.deltaTime);
        RigidbodyT.MoveRotation(newRotation);
    }

    void Movement()
    {

        if (Strafe == true)
        {
            HorizontalMove = Horizontal * Time.deltaTime * Speed;
            VerticalMove = Vertical * Time.deltaTime * Speed;
            transform.Translate(HorizontalMove, 0, VerticalMove);
        }
        else
        {
            if (Horizontal != 0 || Vertical != 0)
            {

                PlayerRotationNorm();
                transform.Translate(transform.forward * Speed * Time.deltaTime, Space.World);
                
            }
        }
       
    }

    void Inputs()
    {
        HC = Input.GetAxis("LeftStickHorizontal");
        VC = Input.GetAxis("LeftStickVertical");
        H = Input.GetAxis("Horizontal");
        V = Input.GetAxis("Vertical");
        if (H != 0 || V != 0)
        {
            Horizontal = H;
            Vertical = V;
            Movement();
        }
        else if (HC != 0 || VC != 0)
        {
            Horizontal = HC;
            Vertical = VC;
            Movement();
        }

        if (Input.GetButtonDown("Jump") && Jumped == false)
        {
            Jump();
            Jumped = true;
        }

        if (Input.GetButtonUp("Jump"))
        {
            Jumped = false;
        }

        if (Input.GetButton("Strafe"))
        {
            Strafe = true;
        }
        else
        {
            Strafe = false;
        }
    }

    void GravityForce()
    {
        if (OnGround == false)
        {
            UpPower -= Gravity * Time.deltaTime;
        }

        if (UpPower <= 0)
        {
            if (Jumped)
            {
                Gravity = floating;
            }
            else
            {
                Gravity = falling;
            }
        }
     
    }
}
