using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeTestingCode : MonoBehaviour
{
    public Rigidbody rigidbody;
    public float Speed;
    // This enum is for convenience, you can go without it if you want, I like to stay organized :)
    public enum DodgeDirection { Right, Left, Forward, Backward }
    // This vector is essential if you want to have variants dodging amounts/forces, it represents how much the player will go to the side, up and forward
    // left: -x, right: +x, up: +y, down: -y, forward: +z, backward: -z. Don't worry you'll understand in a moment
    // if you don't want to have different forces applied to your player when he dodges left/right, forward/backward, just get rid of this vector and use a float variable instead
    public Vector3 dodge = new Vector3(5, 5, 5);
    public Vector3 dodgeRight = new Vector3(5, 5, 5);
    // This is the dodging method, you just give it a direction and it will handle the rest using the `dodge` vector we previously defined.
    public void Dodge(DodgeDirection dir)
    {
        switch (dir)
        {
            case DodgeDirection.Right:
                rigidbody.velocity = Vector3.zero;
                rigidbody.angularVelocity = Vector3.zero;
                rigidbody.AddForce(transform.right * dodgeRight.x + transform.up * dodgeRight.y, ForceMode.Impulse);
                break;
            case DodgeDirection.Left:
                rigidbody.velocity = Vector3.zero;
                rigidbody.angularVelocity = Vector3.zero;
                rigidbody.AddForce(-transform.right * dodge.x + transform.up * dodge.y, ForceMode.Impulse);
                break;
            case DodgeDirection.Forward:
                rigidbody.velocity = Vector3.zero;
                rigidbody.angularVelocity = Vector3.zero;
                rigidbody.AddForce(transform.forward * dodge.z + transform.up * dodge.y, ForceMode.Impulse);
                break;
            case DodgeDirection.Backward:
                rigidbody.velocity = Vector3.zero;
                rigidbody.angularVelocity = Vector3.zero;
                rigidbody.AddForce(-transform.forward * dodge.z + transform.up * dodge.y, ForceMode.Impulse);
                break;
        }
    }
    // Since we're gonna be dealing with a rigidbody and forces, we might as well use FixedUpdate
    // I used 'l', 'j', 'i' and 'k' to dodge left, right, forward and backward (respectively)
    // If I were you and using WASD controls, I would dodge left by double tapping 'A', right by double tapping 'D' etc. (With a threshold I define)
    void FixedUpdate()
    {
        if (Input.GetKeyDown("l"))
            Dodge(DodgeDirection.Right);
        if (Input.GetKeyDown("j"))
            Dodge(DodgeDirection.Left);
        if (Input.GetKeyDown("i"))
            Dodge(DodgeDirection.Forward);
        if (Input.GetKeyDown("k"))
            Dodge(DodgeDirection.Backward);
    }
}
 
