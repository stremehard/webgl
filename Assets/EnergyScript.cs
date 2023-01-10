using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnergyScript : MonoBehaviour
{
    public GameObject[] windows;
    public Material black;
    public Material white;
    private GameObject tempGO;
    private int nrOn;
    private Coroutine switchLightsCoroutine;
    private Coroutine customUpdateCoroutine;
    private int rndSwitchValue;

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

    public IEnumerator CustomUpdate()
    {
        //Coroutine switchLightsCoroutine = SwitchLights();
        while(true)
         {
            nrOn = (windows.Length * (energyT1 + energyT2 + energyT3 + energyT4)) / 400;

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
            nrOn = (windows.Length * (energyT1 + energyT2 + energyT3 + energyT4)) / 400;
            Debug.Log(nrOn);

            if (nrOn >= 768)
            {
                rndSwitchValue = 2;
            }
            else if (nrOn >= 737)
            {
                rndSwitchValue = 4;
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
}