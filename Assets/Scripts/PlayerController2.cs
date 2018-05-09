using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController2 : MonoBehaviour {
    
    public float floating;
    public float falling;
    public float HightOffGround;
    public float turnSmoothing = 15f;
    public Rigidbody RigidbodyT;
    public GameObject Cam;
    float Forward;
    public bool OnGround;
    public static float UpPower;
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

    public float speed;
    public float target = 270.0F;

    Animator anim;


    public static float playerHealth = 10;
    public static float experience;
    public float experienceNeeded = 100;
    public static int healthlevel;
    public static float Armor;
    public bool Armor25 = false;
    public bool Armor50 = false;
    public bool ArmorInvincible = false;

    public float currency;
    public static float souls;
    public GameObject PlayerStats;


    public float X;
    public float Y;
    public float Z;

    // Use this for initialization
    void Start ()
    {
        playerHealth = 10;
        RigidbodyT = gameObject.GetComponent<Rigidbody>();
        healthlevel = 1;
        experience = 0;
        anim = GetComponentInChildren<Animator>();
    }
    public void Health(float newHealth)
    {
        playerHealth = newHealth;
    }
    void Update()
    {
        if (PlayerController2.playerHealth <= 0)
        {
            Speed = 0;
<<<<<<< HEAD
            print("yuo ded");
            //script = GetComponent(thescript);
            (GetComponent("PlayerController2") as MonoBehaviour).enabled = false;
=======
<<<<<<< HEAD
            print("yuo ded");
            //script = GetComponent(thescript);
            (GetComponent("PlayerController2") as MonoBehaviour).enabled = false;
=======
>>>>>>> 197a87e2433339b1db2c2d2b6c8e4591c84d238d
>>>>>>> 49371caf48a1cf4c5c3f76ec4715b69902f575cd
        }
        ArmorChecker();
        Experience();
        if(Input.GetKeyDown(KeyCode.E))
        {
            experience += 100;
        }
        IsGrounded();
        JumpingMovement();

        if (Strafe == true)
        {
            RotatingStrafe();
        }
    }

    void HealthIncrease()
    {
        healthlevel += 1;
        experience = 0;

        switch (healthlevel)
        {
            case 2:
                playerHealth = 20;
                experienceNeeded = 200;
                break;
            case 3:
                playerHealth = 30;
                experienceNeeded = 300;
                break;
            case 4:
                playerHealth = 40;
                experienceNeeded = 400;
                break;
            case 5 :
                playerHealth = 50;
                experienceNeeded = 500;
                break;
            //default: 
        }
    }

    void Experience()
    {
        if (experience >= experienceNeeded)
        {
            HealthIncrease();
        }
    }

    void Dodging()
    { 
        if (Input.GetButtonDown("Crouch") && HC == 0 && VC == 0 && Strafe == false)
        {
            anim.SetTrigger("Dodge Strafe");
            RigidbodyT.velocity = Vector3.zero;
            RigidbodyT.angularVelocity = Vector3.zero;
            RigidbodyT.AddForce(transform.forward * -150 + transform.up * 0, ForceMode.Impulse);
            Debug.Log("aaa");
        }

    }

    // Update is called once per frame
    void FixedUpdate ()
    { 
        Inputs();
        Dodging();
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
            anim.SetBool("Jump", false);
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
            anim.SetBool("Jump", true);
        }
        else if (HasDoubleJump == false)
        {
            UpPower += DoubleJump;
            HasDoubleJump = true;
            anim.SetBool("Jump", true);

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

        if (Input.GetButtonUp("Crouch"))
        {
            gameObject.GetComponent<TrailRenderer>().enabled = false;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            gameObject.GetComponent<TrailRenderer>().enabled = true;
            anim.SetTrigger("Dodge Strafe");
            RigidbodyT.velocity = Vector3.zero;
            RigidbodyT.angularVelocity = Vector3.zero;
            RigidbodyT.AddForce(transform.right * HC * 200 + transform.up * 0, ForceMode.Impulse);
        }
        if (Input.GetButtonDown("Crouch") && HC == 0 && VC == 0 && OnGround == true && H == 0 && V == 0)
        {
            gameObject.GetComponent<TrailRenderer>().enabled = true;
            anim.SetTrigger("Dodge Strafe");
            UpPower += 17;
            HasDoubleJump = true;
        }
        if (Input.GetButtonDown("Crouch") && VC < 0)
        {
            gameObject.GetComponent<TrailRenderer>().enabled = true;
            anim.SetTrigger("Dodge Strafe");
            RigidbodyT.velocity = Vector3.zero;
            RigidbodyT.angularVelocity = Vector3.zero;
            RigidbodyT.AddForce(transform.forward * -200 + transform.up * 0, ForceMode.Impulse);
        }
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
                float ControllerSpeed;
                float Horizontal2; //electric boogaloo
                float Vertical2;

                if (Horizontal < 0)
                {
                    Horizontal2 = Horizontal * -1;
                }
                else
                {
                    Horizontal2 = Horizontal;
                }
                if (Vertical < 0)
                {
                    Vertical2 = Vertical *-1;
                }
                else
                {
                    Vertical2 = Vertical;
                }

                ControllerSpeed = Vertical2 + Horizontal2;
                if (ControllerSpeed > 1)
                {
                    ControllerSpeed = 1;
                }
                PlayerRotationNorm();
                transform.Translate(transform.forward * Speed * Time.deltaTime * ControllerSpeed, Space.World);


                if (Input.GetButtonDown("Crouch"))
                {
                    anim.SetTrigger("Dodge");
                    gameObject.GetComponent<TrailRenderer>().enabled = true;
                    RigidbodyT.velocity = Vector3.zero;
                    RigidbodyT.angularVelocity = Vector3.zero;
                    RigidbodyT.AddForce(transform.forward * 200 + transform.up * 0, ForceMode.Impulse);
                }
                if (Input.GetButtonUp("Crouch"))
                {
                    gameObject.GetComponent<TrailRenderer>().enabled = false;
                }
            }
        }
       
    }

    void Inputs()
    {
        HC = Input.GetAxis("LeftStickHorizontal");
        VC = Input.GetAxis("LeftStickVertical");
        anim.SetFloat("BlendX", HC);
        anim.SetFloat("BlendY", VC);

        H = Input.GetAxis("Horizontal");
        V = Input.GetAxis("Vertical");
        //anim.SetFloat("BlendX", H);
        //anim.SetFloat("BlendY", V);

        if (H != 0 || V != 0)
        {
            Horizontal = H;
            Vertical = V;
            Movement();
            //Speed = 5;
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
            //anim.SetBool("Jump", true);
        }

        if (Input.GetButtonUp("Jump"))
        {
            anim.SetBool("Jump", false);
            Jumped = false;
        }

        if (Input.GetButton("Strafe"))
        {
            Strafe = true;
            anim.SetBool("Strafing", true);
            anim.SetBool("Platforming", false);
        }
        else
        {
            Strafe = false;
            anim.SetBool("Strafing", false);
            anim.SetBool("Platforming", true);
        }
    }

    void JumpingMovement()
    {
        if (Input.GetButton("Crouch") && Input.GetButton("Jump"))
        {
            Debug.Log("AAAAAA");
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

    void ArmorChecker()
    {
        if (Armor25 == true)
        {
            Armor = 25f;
        }
        if (Armor50 == true)
        {
            Armor = 50f;
        }
        if (ArmorInvincible == true)
        {
            Armor = 0f;
        }
        if (Armor25 == false && Armor50 == false && ArmorInvincible == false)
        {
            Armor = 100f;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "EnemyBullet")
        {
            playerHealth -= ((10f * Armor) * Time.deltaTime);
        }
    }



}
