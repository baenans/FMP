using UnityEngine;
using System.Collections;

/**
 * So, I noticed you weren't using the character controller for the movement portion...
 * I guess that's something for later.. However, I think this is working okay.
 * 
 * I disabled a few things as I was working.. (making mistakes of my own , etc.) Obviously you can re-enable your gravity and so on :)
**/
public class MovementPlayer : MonoBehaviour
{

    //Global VAR's
    public static int HP = 100;
    public static int MAXHP = 100;
    public static int STAM = 100;
    public static int MAXSTAM = 100;


    //Movement VAR's
    public float MoveSpeed = 4f;
    public float TurnSpeed = 50.0f;
    public int Can_Run = 0;
    public int Ground = 0;
    public int Gravity = 5;
    private float VertVelocity;


    private Vector3 FORWARD;
    private Vector3 BACK;
    private Vector3 RIGHT;
    private Vector3 LEFT;

    //public Rigidbody PlayerRBody;
    public CharacterController PlayerController;
    Transform mainCam;

    [SerializeField]
    Transform camRig; // for forward dir.
    // Use this for initialization
    void Start()
    {
        //    PlayerRBody = GetComponent<Rigidbody> ();
        PlayerController = GetComponent<CharacterController>();

        //Movement S***.
        FORWARD = MoveSpeed * Vector3.forward;
        BACK = MoveSpeed * Vector3.back;
        RIGHT = MoveSpeed * Vector3.right;
        LEFT = MoveSpeed * Vector3.left;

        mainCam = Camera.main.transform;

        Ground = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
      //  Grav();


    }





    void Movement()
    {

        //If we're on the Ground, react accordingly
        if (Ground == 1)
        {
            //Forward
            if (Input.GetAxis("Vertical") > 0)
            {
                transform.Translate(camRig.forward * MoveSpeed * Time.deltaTime);
                //                transform.Rotate (0,TurnSpeed * Time.deltaTime,0);
            }
            //Backwards
            if (Input.GetAxis("Vertical") < 0)
            {
                transform.Translate(-camRig.forward * MoveSpeed * Time.deltaTime);

            }
            //Right
            if (Input.GetAxis("Horizontal") > 0)
            {
                transform.Translate(MoveSpeed * Time.deltaTime * camRig.right);

            }
            //Left
            if (Input.GetAxis("Horizontal") < 0)
            {
                transform.Translate(-camRig.right * MoveSpeed * Time.deltaTime);

            }

        }
    }



    //Gravity Control.
    void Grav()
    {
        /*
        if (PlayerController.isGrounded)
        {
            VertVelocity = -Gravity * Time.deltaTime;
            Ground = 1;
            Debug.Log("Landed");
        }
        else
        {
            VertVelocity -= Gravity / 4 * Time.deltaTime;
            Debug.Log("In Air");
            Ground = 0;
        }

        Vector3 MoveVector = new Vector3(0, VertVelocity, 0);
        PlayerController.Move(MoveVector * Time.deltaTime);
        */
    }
    
}