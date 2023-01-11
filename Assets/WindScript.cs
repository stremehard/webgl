using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindScript : MonoBehaviour
{
    [Range(0, 480)]
    public float windIntensity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<AudioSource>().volume = windIntensity / 480;
    }

    public void SetWindIntensity(int windIntensity)
    {
        this.windIntensity = windIntensity;
    }
}
