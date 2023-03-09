using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class WindMillScript : MonoBehaviour
{
    [Range(0, 120)]
    public int speed;
    private bool rotate = false;
    public GameObject fire;

    private bool fireOn = false;
    private int currentSpeed = 120;
    private float lerpValue = 0;

    private int state; // 0-Good 1-Error 2-Destroyed

    [DllImport("__Internal")]
    private static extern void TurbineState (int turbineState);

    // Start is called before the first frame update
    void Start()
    {
        state = 0;
        TurbineState();
    }

    // Update is called once per frame
    void Update()
    {
        if(rotate){
            transform.Rotate(new Vector3(0, 0, Input.GetAxis("Mouse Y")) * Time.deltaTime * 2000);
        } 
        else
        {
            transform.Rotate(new Vector3(0, 0, 0.1f) * Time.deltaTime * speed * 20);
        }

        if(fireOn && lerpValue<=1)
        {
            speed = (int)Mathf.Lerp(currentSpeed, 0, lerpValue);
            lerpValue += 0.001f;
        }

        if (speed == 120)
        {
            SetFire();
        }
    }

    public void SetSpeed(int speed)
    {
        if(!rotate && !fireOn)
        {
            this.speed = speed;
        }
        else if(rotate && !fireOn)
        {
            this.speed = 0;
        }
    }

    public int GetSpeed()
    {
        return this.speed;
    }

    void OnMouseDown()
    {
        if(state != 2)
        {
            state = 1;
            TurbineState();
        }
        rotate = true;
    }

    void OnMouseUp()
    {
        if(state != 2)
        {
            state = 0;
            TurbineState();
        }
        rotate = false;
    }

    public void SetFire()
    {
        state = 2;
        TurbineState();
        fire.SetActive(true);
        currentSpeed = this.speed;
        fireOn = true;
    }

    public void TurbineState()
    {
        #if UNITY_WEBGL == true && UNITY_EDITOR == false
            TurbineState(state);
        #endif
    }
}
