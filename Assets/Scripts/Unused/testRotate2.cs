using UnityEngine;
using System.Collections;

public class testRotate2 : MonoBehaviour
{

    public Transform center;
    public Vector3 axis = Vector3.up;
    public Vector3 desiredPosition;
    public float radius = 2.0f;
    public float radiusSpeed = 0.5f;
    public float rotationSpeed = 80.0f;
    public Transform orbitor;
    public bool isRotating;

    void Start()
    {
        orbitor.transform.position = (orbitor.transform.position - center.position).normalized * radius + center.position;
        //radius = 2.0f;
    }

    void Update()
    {
        if (isRotating == true)
        {
            orbitor.transform.RotateAround(center.position, axis, rotationSpeed * Time.deltaTime);
            desiredPosition = (orbitor.transform.position - center.position).normalized * radius + center.position;
            orbitor.transform.position = Vector3.MoveTowards(orbitor.transform.position, desiredPosition, Time.deltaTime * radiusSpeed);
        }
        // Vector3 tangentVector = Quaternion.Euler(0, 90, 0) * (transform.position - center.position);
        //transform.rotation = Quaternion.LookRotation(tangentVector);
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isRotating = false;
        }
    }
}