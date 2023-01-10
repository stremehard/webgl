using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindMillScript : MonoBehaviour
{
    [Range(0, 120)]
    public int speed;
    private bool rotate = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(rotate){
            transform.Rotate(new Vector3(0, 0, Input.GetAxis("Mouse Y")) * Time.deltaTime * 2000);
        } else {
            transform.Rotate(new Vector3(0, 0, 0.1f) * Time.deltaTime * speed * 20);
        }
    }

    public void SetSpeed(int speed)
    {
        if(!rotate)
        {
            this.speed = speed;
        }
        else
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
}
