using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindMillScript : MonoBehaviour
{
    private float speed = 1000;
    private bool rotate = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(rotate){
            transform.Rotate(new Vector3(0, 0, Input.GetAxis("Mouse Y")) * Time.deltaTime * speed);
        } else {
            transform.Rotate(new Vector3(0, 0, 0.1f) * Time.deltaTime * speed);
        }
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
