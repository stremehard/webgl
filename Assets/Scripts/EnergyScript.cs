using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class EnergyScript : MonoBehaviour
{
    public GameObject[] windows;
    public FireScript fireScript;
    public Material black;
    public Material white;
    private GameObject tempGO;
    private int nrOn;
    private Coroutine switchLightsCoroutine;
    private Coroutine customUpdateCoroutine;
    private int rndSwitchValue;
    public WindMillScript w1;
    public WindMillScript w2;
    public WindMillScript w3;
    public WindMillScript w4;
    public GameObject easterEgg;
    public WeatherScript weatherScript;

    private int speed1;
    private int speed2;
    private int speed3;
    private int speed4;

    [Range(0, 120)]
    public int energyT1;
    [Range(0, 120)]
    public int energyT2;
    [Range(0, 120)]
    public int energyT3;
    [Range(0, 120)]
    public int energyT4;

    // Start is called before the first frame update
    void Start()
    {
        windows = GameObject.FindGameObjectsWithTag("window"); //641 windows
        windows = ShuffleWindows(windows);
        customUpdateCoroutine = StartCoroutine(CustomUpdate());
    }

    private void FixedUpdate()
    {
        weatherScript.SetWindIntensity(energyT1+energyT2+energyT3+energyT4);
        
        w1.SetSpeed(energyT1);
        w2.SetSpeed(energyT2);
        w3.SetSpeed(energyT3);
        w4.SetSpeed(energyT4);

        speed1 = w1.GetSpeed();
        speed2 = w2.GetSpeed();
        speed3 = w3.GetSpeed();
        speed4 = w4.GetSpeed();
    }

    public IEnumerator CustomUpdate()
    {
        //Coroutine switchLightsCoroutine = SwitchLights();
        while(true)
         {
            nrOn = (windows.Length * (speed1 + speed2 + speed3 + speed4)) / 400;

            if (nrOn <= windows.Length)
            {
                for (int i = 0; i < nrOn; i++)
                {
                    windows[i].GetComponent<MeshRenderer>().material = white;
                }

                for (int i = nrOn; i < windows.Length; i++)
                {
                    windows[i].GetComponent<MeshRenderer>().material = black;
                }
            } 
            else
            {
                switchLightsCoroutine = StartCoroutine(SwitchLights(windows));
                StopCoroutine(customUpdateCoroutine);
            }

            yield return new WaitForSeconds(0.05f);
        }
    }

    public GameObject[] ShuffleWindows(GameObject[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            int rnd = Random.Range(0, array.Length);
            tempGO = array[rnd];
            array[rnd] = array[i];
            array[i] = tempGO;
        }

        return array;
    }

    IEnumerator SwitchLights(GameObject[] windows)
    {
        while (true)
        {
            nrOn = (windows.Length * (speed1 + speed2 + speed3 + speed4)) / 400;

            if (nrOn >= 737)
            {
                //game over
                rndSwitchValue = 4;
                fireScript.on = true;
                StartCoroutine(GameOver());
            }
            else if (nrOn >= 705)
            {
                rndSwitchValue = 8;
            }
            else if (nrOn >= 673)
            {
                rndSwitchValue = 16;
            }
            else if (nrOn > 641)
            {
                rndSwitchValue = 32;
            }
            else
            {
                customUpdateCoroutine = StartCoroutine(CustomUpdate());
                StopCoroutine(switchLightsCoroutine);
            }

            for (int i = 0; i < windows.Length; i++)
            {
                if (Random.Range(0, rndSwitchValue) == 0)
                {
                    windows[i].GetComponent<MeshRenderer>().material = black;
                }
                else
                {
                    windows[i].GetComponent<MeshRenderer>().material = white;
                }
            }

            yield return new WaitForSeconds(0.05f);
        }
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(0.5f);
        w1.SetFire();
        yield return new WaitForSeconds(0.5f);
        w2.SetFire();
        yield return new WaitForSeconds(0.5f);
        w3.SetFire();
        yield return new WaitForSeconds(0.5f);
        w4.SetFire();
        yield return new WaitForSeconds(5);
        easterEgg.SetActive(true);
    }

    //scripts for React
    public void SetEnergyT1(int x) //from 0 to 120
    {
        if(x>=0 && x<=120)
        {
            this.energyT1 = x;
        }
    }
    public void SetEnergyT2(int x) //from 0 to 120
    {
        if(x>=0 && x<=120)
        {
            this.energyT2 = x;   
        }
    }
    public void SetEnergyT3(int x) //from 0 to 120
    {
        if(x>=0 && x<=120)
        {
            this.energyT3 = x;
        }
    }
    public void SetEnergyT4(int x) //from 0 to 120
    {
        if(x>=0 && x<=120)
        {
            this.energyT4 = x;
        }
    }
    public void SetEnergyAllT(int x) //from 0 to 120
    {
        if(x>=0 && x<=120)
        {
            this.energyT1 = x;
            this.energyT2 = x;
            this.energyT3 = x;
            this.energyT4 = x;
        }
    }
    public void SetBrightness(int x) //from 0 to 2 (2 default)
    {
        if(x>=0 && x<=2)
        {
            weatherScript.SetBrightness(x);
        }
    }
    public void SetCloudIntensity(int x) //from 7 to 15 (7 default)
    {
        if(x>=7 && x<=15)
        {
            weatherScript.SetCloudIntensity(x);
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene("Main");
    }
}