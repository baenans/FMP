using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    // Variables
	public GameObject Cam;
    Rigidbody rigidbodyT;

	public float turnSmoothing = 15f; // A smoothing value for turning the player.
	public float speedDampTime = 0.1f; // The damping for the speed parameter
    public float walkSpeed = 2;
    public float speed = 6.0F;
	public float jumpForce = 7;
	public float DoubleJumpPower;

    private Vector3 moveDirection = Vector3.zero;
    private Animator anim; // Reference to the animator component.
    public LayerMask groundLayers;
    
	public bool DoubleJump = false;
	public bool Strafe = false;
    public float threshold;


    // Functions
    void Awake()
    {
        //anim = GetComponent<Animator>();
    }

    private void Start()
    {
		rigidbodyT = GetComponent<Rigidbody>();
        
    }

    void FixedUpdate()
    {
        // Cache the inputs.
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        MovementManagement(h, v);
        if (transform.position.y < threshold)
            transform.position = new Vector3(0, 0, 0);
        if (IsGrounded() && Input.GetKey(KeyCode.Space))
        {
            rigidbodyT.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        }
        else if (Input.GetKeyDown(KeyCode.Space) && DoubleJump == false)
        {
            DoubleJump = true;
            rigidbodyT.AddForce(Vector3.up * jumpForce * DoubleJumpPower, ForceMode.Impulse);
        }

    }

    void Update()
    {
		
		//if (IsGrounded () && Input.GetKey (KeyCode.Space)) {
		//	rigidbodyT.AddForce (Vector3.up * jumpForce, ForceMode.Impulse);

		//} 
		//else if (Input.GetKeyDown (KeyCode.Space) && DoubleJump == false)
		//{ 
		//	DoubleJump = true;
		//	rigidbodyT.AddForce (Vector3.up * jumpForce * DoubleJumpPower, ForceMode.Impulse);
		//}
    }

    /////////////////////////////////////////////CHARACTER MOVEMENT/////////////////////////////////////////

    void MovementManagement(float horizontal, float vertical)
    {
        // If there is some axis input...
        if (horizontal != 0f || vertical != 0f)
        {
			if (Strafe == false) {
				// ... set the players rotation and set the speed parameter to 5.3f.
				Rotating (horizontal, vertical);
			} else {
				RotatingStrafe (horizontal, vertical);
			}
        }

    }

    void Rotating(float horizontal, float vertical)
    {
        // Create a new vector of the horizontal and vertical inputs.
		Vector3 direction = new Vector3(horizontal, 0f, vertical);


        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
        direction = Camera.main.transform.TransformDirection(direction);
       direction.y = 0.0f;
        //this.transform.position += Vector3.Normalize(direction);

        // Create a rotation based on this new vector assuming that up is the global y axis.
        Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);

        // Create a rotation that is an increment closer to the target rotation from the player's rotation.
        Quaternion newRotation = Quaternion.Lerp(rigidbodyT.rotation, targetRotation, turnSmoothing * Time.deltaTime);

        // Change the players rotation to this new rotation.
        rigidbodyT.MoveRotation(newRotation);
    }

	void RotatingStrafe(float horizontal, float vertical)
	{
		Vector3 movement = new Vector3 (horizontal, 0, vertical);
		transform.Translate (movement * speed * Time.deltaTime, Space.Self);

		Vector3 direction = new Vector3(0f, 0f, 0f);
		direction = Cam.transform.forward;
		direction.y = 0.0f;
		Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
		Quaternion newRotation = Quaternion.Lerp(rigidbodyT.rotation, targetRotation, turnSmoothing * Time.deltaTime);
		rigidbodyT.MoveRotation(newRotation);
	}

    private bool IsGrounded()
    {        
		if (Physics.Raycast(gameObject.transform.position,Vector3.down,1))
			{
				DoubleJump = false;
				return true;
			} else 
			{
				return false;
			}
    }


}