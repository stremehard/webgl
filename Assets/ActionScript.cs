using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionScript : MonoBehaviour
{
    public bool rotating = false;
    private Vector3 fromRotation;
    private float rotateValue = 0;
    private float speed = 20;

    // Start is called before the first frame update
    void Start()
    {
        
        fromRotation = transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if(rotateValue < 360 && rotating){
            transform.eulerAngles += new Vector3(0,speed,0);
            rotateValue += speed;
        } else {
            transform.eulerAngles = fromRotation;
            rotateValue = 0;
            rotating = false;
        }
    }

    public void OnMouseDown()
    {
        rotating = true;
    }
}
