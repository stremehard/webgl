using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindMillScript : MonoBehaviour
{
    [Range(0, 120)]
    public int speed;
    private bool rotate = false;
    public GameObject fire;

    private bool fireOn = false;
    private int currentSpeed = 120;
    private float lerpValue = 0;

    // Start is called before the first frame update
    void Start()
    {

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
        rotate = true;
    }

    void OnMouseUp()
    {
        rotate = false;
    }

    public void SetFire()
    {
        fire.SetActive(true);
        currentSpeed = this.speed;
        fireOn = true;
    }
}
