using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleHook : MonoBehaviour
{

    public Transform cam;
    public RaycastHit hit;
    public bool attached = false;
    public float momentum;
    public float step;
    public GameObject target;

    private Rigidbody rb;
    public float speed;

    public float degree = 270.0F;
    public float speed1 = 45.0F;

    public LineRenderer lr;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (Physics.Raycast(cam.position, cam.forward, out hit))
            {
                attached = true;
                rb.isKinematic = true;
                PlayerController2.UpPower = 0;
            }
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            attached = false;
            rb.isKinematic = false;
            rb.velocity = cam.forward * momentum;
            momentum = 0;
        }
        if (attached)
        {
            PlayerController2.UpPower = 0;
            momentum = Time.deltaTime * speed;
            step = momentum * Time.deltaTime;
            //transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
            //float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.y, degree, speed * Time.deltaTime);

            //transform.position = Vector3.MoveTowards(transform.position, hit.point, step);
            //transform.parent.position = Vector3.MoveTowards(transform.position, target.transform.position, 7 * Time.deltaTime);
        }
        if (!attached && momentum >= 0)
        {
            momentum -= 0 * Time.deltaTime;
            step = 0;
        }
    }



}
