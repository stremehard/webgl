using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherScript : MonoBehaviour
{
    [Range(0, 480)]
    public float windIntensity;
    [Range(7, 15)]
    public float cloudIntensity;
    [Range(0, 2)]
    public float brightness;
    public Material skyCloudyMaterial;
    public Light directionalLight;
    public Material grass;
    public SpriteRenderer mountains;
    public SpriteRenderer mountains1;
    public SpriteRenderer mountains2;

    private Color32 darkGrass;
    private Color32 brightGrass;
    private Color32 darkMountains;
    private Color32 brightMountains;
    private float lerpGrassValue = 0;

    // Start is called before the first frame update
    void Start()
    {
        cloudIntensity = 1.4f;
        brightness = 2f;
        darkGrass = new Color32(24,24,24,255);
        brightGrass = new Color32(55,55,55,255);
        darkMountains = new Color32(22,22,22,255);
        brightMountains = new Color32(200,200,200,255);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<AudioSource>().volume = windIntensity / 480;
        skyCloudyMaterial.SetFloat("_Rotation", Time.time * cloudIntensity);
        skyCloudyMaterial.SetFloat("_Exposure", brightness);
        directionalLight.intensity = brightness;
        mountains.color = Color32.Lerp(darkMountains, brightMountains, brightness/2);
        mountains1.color = Color32.Lerp(darkMountains, brightMountains, brightness/2);
        mountains2.color = Color32.Lerp(darkMountains, brightMountains, brightness/2);
        if(brightness>=1.41)
        {
            lerpGrassValue = (brightness-1.41f)/0.59f;
        } 
        else 
        {
            lerpGrassValue = 0;
        }
        grass.color = Color32.Lerp(darkGrass, brightGrass, lerpGrassValue);
    }

    public void SetWindIntensity(int windIntensity)
    {
        this.windIntensity = windIntensity;
    }

    public void SetCloudIntensity(int cloudIntensity)
    {
        this.cloudIntensity = cloudIntensity;
    }

    public void SetBrightness(int brightness) //2 default
    {
        this.brightness = brightness;
    }
}
