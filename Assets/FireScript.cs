using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{
    public bool on = false;
    public GameObject[] explosions;
    public GameObject[] fires;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (on)
        {
            Explode();
        }
    }

    public void Explode()
    {
        StartCoroutine(ExplodeCoroutine());
    }

    IEnumerator ExplodeCoroutine()
    {
        foreach(GameObject explosion in explosions)
        {
            explosion.SetActive(true);
            yield return new WaitForSeconds(1);
        }
        StartCoroutine(FireCoroutine());
    }

    IEnumerator FireCoroutine()
    {
        foreach (GameObject fire in fires)
        {
            fire.SetActive(true);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
