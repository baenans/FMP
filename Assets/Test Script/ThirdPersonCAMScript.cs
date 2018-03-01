using UnityEngine;
using System.Collections;

public class ThirdPersonCAMScript : MonoBehaviour
{

    private const float Y_ANGLE_MIN = 0;
    private const float Y_ANGLE_MAX = 30.0f;

    public Transform lookAt;
    public Transform camTransform;

    private Camera cam;

    private float distance = 10.0f;
    public float currentX = 0.0f;
    public float currentY = 0.0f;
    private float sensitivityX = 4.0f;
    private float sensitivityY = 1.0f;
    [SerializeField]
    Transform camPivot;
    [SerializeField]
    Transform camRig;
    

    // Update is called once per frame
    void LateUpdate()
    {
        currentX += Input.GetAxis("Mouse X");
        currentY += Input.GetAxis("Mouse Y");

        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
        camRig.rotation = Quaternion.Euler(0, currentX, 0);
        camPivot.localRotation = Quaternion.Euler(currentY,0, 0);

        camRig.position = lookAt.position;
    }

    // Update is called once per frame
    /*
    void LateUpdate()
    {
        
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        camTransform.position = lookAt.position + rotation * dir;
        camTransform.LookAt(lookAt.position);
        
    }
    */
}
