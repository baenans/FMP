using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickTest : MonoBehaviour {

    public Vector2 A1P1;
    public Vector2 A1P2;
    public Vector2 A1P3;
    public Vector2 A2P1;
    public Vector2 A2P2;
    public Vector2 A2P3;
    public Vector2 A3P1;
    public Vector2 A3P2;
    public Vector2 A3P3;

    public float Horizontal;
    public float Vertical;

    void Update()
    {
        Horizontal = Input.GetAxis("RightStickHorizontal");
        Vertical = Input.GetAxis("RightStickVertical");

        if (PointCheck(new Vector2(Horizontal, Vertical), A1P1, A1P2, A1P3))
        {
            Debug.Log("in Area 1                      " + Horizontal + " "+ Vertical);
        }

        if (PointCheck(new Vector2(Horizontal, Vertical), A2P1, A2P2, A2P3))
        {
            Debug.Log("in Area 2                      " + Horizontal + " " + Vertical);
        }

        if (PointCheck(new Vector2(Horizontal, Vertical), A3P1, A3P2, A3P3))
        { 
            Debug.Log("in Area 3                      " + Horizontal + " "+ Vertical);
        }


    }

    float Area(Vector2 P1, Vector2 P2, Vector2 P3)
    {
        float A1 = P2.y - P3.y;

        float A2 = P3.y - P1.y;

        float A3 = P1.y - P2.y;


        A1 = A1 * P1.x;

        A2 = A2 * P2.x;

        A3 = A3 * P3.x;


        float Area = (A1 + A2 + A3) / 2;

        return Area;

    }

    bool IsPointInAreaTriangle(Vector2 P1, Vector2 P2, Vector2 P3, Vector2 TargetPoint)
    {
        float A1 = Area(P1, P2, P3);
        float A2 = Area(TargetPoint, P2, P3);
        float A3 = Area(P1, TargetPoint, P3);
        float A4 = Area(P1, P2, TargetPoint);

        if (A1 == (A2 + A3 + A4))
        {
            return true;
        }
        else

        {
            return false;
        }

    }

    bool IsPointAreaSquare(Vector2 P1, Vector2 P2, Vector2 TargetPoint)
    {
        bool x = false;
        bool y = false;

        if ((P1.x > TargetPoint.x && TargetPoint.x > P2.x) || (P1.x < TargetPoint.x && TargetPoint.x < P2.x))
        {
            x = true;
        }

        if ((P1.y > TargetPoint.y && TargetPoint.y > P2.y) || (P1.y < TargetPoint.y && TargetPoint.y < P2.y))
        {
            y = true;
        }

        if (x == true && y == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }



    bool PointCheck(Vector2 TargetPoint, Vector2 P1, Vector2 P2, Vector2 P3)
    {
        if (IsPointInAreaTriangle(P1, P2, P3, TargetPoint) || IsPointAreaSquare(P2, P3, TargetPoint))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}