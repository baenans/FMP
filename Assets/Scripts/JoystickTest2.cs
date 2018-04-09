using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickTest2 : MonoBehaviour {
    public bool weaponsSelecting = false;
    public float v;
    public float h;
    public float H;
    public float V;
    public float maxX;
    public float maxY;
    public float currentX;
    public float currentY;
    public float mouseMultiplier;

    // Use this for initialization
    void Start () {
        maxX = Screen.width/2;
        maxY = Screen.height/2;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButton("Weapons"))
        {
            weaponsSelecting = true;
            ShowWheel();
                Time.timeScale = 0.001F;
            
        }
        else
        {
            weaponsSelecting = false;
            Time.timeScale = 1.0F;
            HideWheel();
        }
        Time.fixedDeltaTime = 0.01F * Time.timeScale;
        if (weaponsSelecting == true)
        {
            h = Input.GetAxis("LeftStickHorizontal");
            v = Input.GetAxis("LeftStickVertical");
            H = Input.GetAxis("Mouse X") * mouseMultiplier;
            V = Input.GetAxis("Mouse Y") * -mouseMultiplier ;
            if (h != 0 || v != 0)
            {
                Controller();
            }
            else if(H != 0 || V != 0)
            {
                Mouse();
            }
        }
    }
    public void ShowWheel()
    {
        int max = transform.parent.childCount;
        int i = 0;
        while (i != max)
        {
            transform.parent.GetChild(i).GetComponent<Renderer>().enabled = true;
            i += 1;
        }
    }
    public void HideWheel()
    {
        int max = transform.parent.childCount;
        int i = 0;
        while (i != max)
        {
            transform.parent.GetChild(i).GetComponent<Renderer>().enabled = false;
            i += 1;
        }
    }
    public void Controller()
    {
        transform.localPosition = new Vector3(h, 0, v);
    }
    public void Mouse()
    {
        if(currentX + H < maxX && currentX + H > -maxX)
        {
            currentX += H;
        }
        if (currentY + V < maxY && currentY + V > -maxY)
        {
            currentY += V;
        }
        transform.localPosition = new Vector3(currentX/maxX, 0, currentY/maxY);
    }
}
